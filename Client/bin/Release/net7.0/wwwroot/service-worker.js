/* Manifest version: Q294GFiQ */
/* Manual Version Controlled Service Worker */

self.importScripts('./service-worker-assets.js');

self.addEventListener('install', event => event.waitUntil(onInstall(event)));
self.addEventListener('activate', event => event.waitUntil(onActivate(event)));
self.addEventListener('fetch', event => event.respondWith(onFetch(event)));

// 🔥 CACHE CONFIG
const cacheNamePrefix = 'offline-cache-';

// 👉 IMPORTANT: deployment वेळी version change कर
const CACHE_VERSION = self.assetsManifest.version;

const cacheName = `${cacheNamePrefix}${CACHE_VERSION}`;

// Files to cache
const offlineAssetsInclude = [
    /\.dll$/, /\.pdb$/, /\.wasm/, /\.html/, /\.js$/, /\.json$/,
    /\.css$/, /\.woff$/, /\.png$/, /\.jpe?g$/, /\.gif$/, /\.ico$/,
    /\.blat$/, /\.dat$/
];

const offlineAssetsExclude = [/^service-worker\.js$/];


// ==============================
// 🔥 PUSH NOTIFICATION
// ==============================
self.addEventListener('push', event => {
    if (!event.data) return;

    const payload = event.data.json();

    const options = {
        body: payload.message,
        icon: '/icon-512.png',
        badge: '/icon-192.png',
        vibrate: [100, 50, 100],
        data: { url: payload.url }
    };

    event.waitUntil(
        self.registration.showNotification(payload.title, options)
    );
});

// Notification click
self.addEventListener('notificationclick', event => {
    event.notification.close();
    const url = event.notification.data?.url || "/";

    event.waitUntil(
        clients.matchAll({ type: "window", includeUncontrolled: true })
            .then(clientList => {
                for (const client of clientList) {
                    if (client.url.includes(url) && 'focus' in client)
                        return client.focus();
                }
                return clients.openWindow(url);
            })
    );
});


// ==============================
// 🔥 INSTALL
// ==============================
async function onInstall(event) {
    console.info('Service worker: Install');

   // self.skipWaiting(); // 🔥 new SW activate faster

    const assetsRequests = self.assetsManifest.assets
        .filter(asset => offlineAssetsInclude.some(pattern => pattern.test(asset.url)))
        .filter(asset => !offlineAssetsExclude.some(pattern => pattern.test(asset.url)))
        .map(asset => new Request(asset.url, { cache: 'no-cache' }));

    const cache = await caches.open(cacheName);
    await cache.addAll(assetsRequests);
}


// ==============================
// 🔥 ACTIVATE
// ==============================
async function onActivate(event) {
    console.info('Service worker: Activate');

    await self.clients.claim(); // 🔥 take control immediately

    const cacheKeys = await caches.keys();

    await Promise.all(
        cacheKeys
            .filter(key => key.startsWith(cacheNamePrefix) && key !== cacheName)
            .map(key => caches.delete(key))
    );
}


// ==============================
// 🔥 FETCH (NETWORK FIRST)
// ==============================
async function onFetch(event) {

    if (event.request.method !== 'GET') {
        return fetch(event.request);
    }

    const shouldServeIndexHtml = event.request.mode === 'navigate';
    const request = shouldServeIndexHtml ? 'index.html' : event.request;

    const cache = await caches.open(cacheName);
    const cachedResponse = await cache.match(request);

    try {
        // 🔥 always try fresh data first
        const networkResponse = await fetch(event.request);

        // optionally update cache
        cache.put(request, networkResponse.clone());

        return networkResponse;
    } catch (error) {
        // 🔥 fallback to cache if offline
        return cachedResponse;
    }
}


// ==============================
// 🔥 SKIP WAITING (UPDATE BUTTON)
// ==============================
self.addEventListener('message', event => {
    if (event.data && event.data.action === 'skipWaiting') {
        self.skipWaiting();
    }
});