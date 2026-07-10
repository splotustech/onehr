plugins {
    alias(libs.plugins.android.application)
    alias(libs.plugins.kotlin.android)
}

android {
    namespace = "com.splotus.smarthrms"
    compileSdk = 34

    defaultConfig {
        applicationId = "com.splotus.smarthrms"
        minSdk = 21          // Android 5.0 — covers 99%+ of active devices
        targetSdk = 34
        versionCode = 1
        versionName = "1.0.0"

        // ── SERVER URL ─────────────────────────────────────────────────────
        // Change this to your production server URL before building the APK
        buildConfigField("String", "SERVER_URL", "\"https://onehr.splotustech.com\"")
    }

    buildFeatures {
        buildConfig = true
        viewBinding = true
    }

    buildTypes {
        debug {
            isDebuggable = true
            // For local testing: use your PC's IP (e.g. http://192.168.1.100:5158)
            buildConfigField("String", "SERVER_URL", "\"https://onehr.splotustech.com\"")
        }
        release {
            isMinifyEnabled = true
            proguardFiles(getDefaultProguardFile("proguard-android-optimize.txt"), "proguard-rules.pro")
            buildConfigField("String", "SERVER_URL", "\"https://onehr.splotustech.com\"")
        }
    }

    compileOptions {
        sourceCompatibility = JavaVersion.VERSION_17
        targetCompatibility = JavaVersion.VERSION_17
    }
    kotlinOptions {
        jvmTarget = "17"
    }
}

dependencies {
    implementation(libs.androidx.core.ktx)
    implementation(libs.androidx.appcompat)
    implementation(libs.material)
    implementation(libs.play.services.location)   // FusedLocationProviderClient
    implementation(libs.okhttp)                   // HTTP client for GPS pings
    implementation(libs.kotlinx.coroutines.android)
}
