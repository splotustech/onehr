# OkHttp
-dontwarn okhttp3.**
-dontwarn okio.**
-keep class okhttp3.** { *; }
-keep class okio.** { *; }

# Google Play Services Location
-keep class com.google.android.gms.location.** { *; }

# JavaScript Bridge — must NOT be obfuscated
-keepclassmembers class com.splotus.smarthrms.WFHJavascriptBridge {
    @android.webkit.JavascriptInterface <methods>;
}

# Keep service and receiver
-keep class com.splotus.smarthrms.WFHLocationService { *; }
-keep class com.splotus.smarthrms.BootReceiver { *; }
-keep class com.splotus.smarthrms.MainActivity { *; }
