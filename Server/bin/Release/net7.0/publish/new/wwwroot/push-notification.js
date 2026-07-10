window.pushNotifications = {

    publicVapidKey: "BPdHp1GBJ5-_apY5jYru_kiZuBja89HxGcZCsLFa06nsT1zaeGkrtz1EpXI1WM7ijcQ8So5DqNXTKH8wEUmcGJM",

    subscribe: async function (empId, department) {
        try {
            console.log("🔔 Starting push subscription...");

            if (!('serviceWorker' in navigator) || !('PushManager' in window)) {
                console.warn("❌ Push notifications not supported in this browser");
                return;
            }

            let permission = Notification.permission;
            if (permission !== 'granted') {
                permission = await Notification.requestPermission();
            }

            if (permission !== 'granted') {
                console.warn("❌ Notification permission denied");
                return;
            }

            // २. Service Worker रजिस्टर करणे
  let registration = await navigator.serviceWorker.getRegistration();
  if (!registration) {
      console.log("⚙️ [Push] Registering Service Worker...");
      registration = await navigator.serviceWorker.register('/service-worker.js');
  }

  await navigator.serviceWorker.ready;
  console.log("✅ [Push] Service Worker is ready.");

  // ३. Subscription मिळवणे किंवा नवीन बनवणे
  let subscription = await registration.pushManager.getSubscription();

            if (!subscription) {
                console.log("🆕 Creating new subscription...");
                subscription = await registration.pushManager.subscribe({
                    userVisibleOnly: true,
                    applicationServerKey: this.urlB64ToUint8Array(this.publicVapidKey)
                });
            }

            // 🔥 BEST and SAFEST way to extract Endpoint and Keys
            const subData = JSON.parse(JSON.stringify(subscription));

            const payload = {
                empId: parseInt(empId),
                department: department || "",
                endpoint: subData.endpoint,
                p256dh: subData.keys.p256dh,
                auth: subData.keys.auth
            };

            console.log("📤 Sending payload:", payload);

            const response = await fetch('/api/notifications/subscribe', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload)
            });

            if (response.ok) {
                console.log("✅ User subscribed successfully!");
            } else {
                console.error("❌ Server error:", response.status);
            }

        } catch (error) {
            console.error("❌ Push subscription error:", error);
        }
    },

    urlB64ToUint8Array: function (base64String) {
        const padding = '='.repeat((4 - base64String.length % 4) % 4);
        const base64 = (base64String + padding)
            .replace(/-/g, '+')
            .replace(/_/g, '/');

        const rawData = window.atob(base64);
        const outputArray = new Uint8Array(rawData.length);

        for (let i = 0; i < rawData.length; ++i) {
            outputArray[i] = rawData.charCodeAt(i);
        }
        return outputArray;
    }
};