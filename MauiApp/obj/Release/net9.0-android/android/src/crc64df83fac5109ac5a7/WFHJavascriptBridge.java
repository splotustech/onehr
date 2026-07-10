package crc64df83fac5109ac5a7;


public class WFHJavascriptBridge
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_StartNativeTracking:(I)V:__export__\n" +
			"n_StopNativeTracking:()V:__export__\n" +
			"n_IsNativeApp:()Z:__export__\n" +
			"n_GetDeviceInfo:()Ljava/lang/String;:__export__\n" +
			"n_GetAppVersion:()Ljava/lang/String;:__export__\n" +
			"n_DownloadFile:(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("SPOneHRApp.WFHJavascriptBridge, SPOneHR", WFHJavascriptBridge.class, __md_methods);
	}

	public WFHJavascriptBridge ()
	{
		super ();
		if (getClass () == WFHJavascriptBridge.class) {
			mono.android.TypeManager.Activate ("SPOneHRApp.WFHJavascriptBridge, SPOneHR", "", this, new java.lang.Object[] {  });
		}
	}

	public WFHJavascriptBridge (android.content.Context p0, java.lang.String p1)
	{
		super ();
		if (getClass () == WFHJavascriptBridge.class) {
			mono.android.TypeManager.Activate ("SPOneHRApp.WFHJavascriptBridge, SPOneHR", "Android.Content.Context, Mono.Android:System.String, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1 });
		}
	}

@android.webkit.JavascriptInterface
	public void startNativeTracking (int p0)
	{
		n_StartNativeTracking (p0);
	}

	private native void n_StartNativeTracking (int p0);

@android.webkit.JavascriptInterface
	public void stopNativeTracking ()
	{
		n_StopNativeTracking ();
	}

	private native void n_StopNativeTracking ();

@android.webkit.JavascriptInterface
	public boolean isNativeApp ()
	{
		return n_IsNativeApp ();
	}

	private native boolean n_IsNativeApp ();

@android.webkit.JavascriptInterface
	public java.lang.String getDeviceInfo ()
	{
		return n_GetDeviceInfo ();
	}

	private native java.lang.String n_GetDeviceInfo ();

@android.webkit.JavascriptInterface
	public java.lang.String getAppVersion ()
	{
		return n_GetAppVersion ();
	}

	private native java.lang.String n_GetAppVersion ();

@android.webkit.JavascriptInterface
	public void downloadFile (java.lang.String p0, java.lang.String p1, java.lang.String p2)
	{
		n_DownloadFile (p0, p1, p2);
	}

	private native void n_DownloadFile (java.lang.String p0, java.lang.String p1, java.lang.String p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
