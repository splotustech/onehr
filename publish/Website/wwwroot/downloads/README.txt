SP OneHR - App Downloads Folder
================================

ANDROID APK:
  Place your built APK here with the name: SpOneHR.apk

  To build the APK:
  1. Open AndroidApp/ folder in Android Studio
  2. Update SERVER_URL in app/build.gradle.kts
  3. Build > Build Bundle/APK > Build APK
  4. Copy app-release.apk from app/build/outputs/apk/release/
  5. Rename to SpOneHR.apk and paste in this folder

  Download URL: https://onehr.splotustech.com/downloads/SpOneHR.apk

iOS:
  No APK for iOS. Users must use Safari > Add to Home Screen.
  The iOS Install Guide modal in the app explains the steps.

MIME TYPE NOTE:
  ASP.NET Core does not serve .apk files by default.
  The Program.cs file has been updated to add the APK MIME type.
