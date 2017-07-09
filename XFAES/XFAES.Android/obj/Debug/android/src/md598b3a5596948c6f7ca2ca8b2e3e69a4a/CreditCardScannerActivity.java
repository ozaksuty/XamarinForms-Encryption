package md598b3a5596948c6f7ca2ca8b2e3e69a4a;


public class CreditCardScannerActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onActivityResult:(IILandroid/content/Intent;)V:GetOnActivityResult_IILandroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("XFAES.Droid.CreditCardScannerActivity, XFAES.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CreditCardScannerActivity.class, __md_methods);
	}


	public CreditCardScannerActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CreditCardScannerActivity.class)
			mono.android.TypeManager.Activate ("XFAES.Droid.CreditCardScannerActivity, XFAES.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onActivityResult (int p0, int p1, android.content.Intent p2)
	{
		n_onActivityResult (p0, p1, p2);
	}

	private native void n_onActivityResult (int p0, int p1, android.content.Intent p2);

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
