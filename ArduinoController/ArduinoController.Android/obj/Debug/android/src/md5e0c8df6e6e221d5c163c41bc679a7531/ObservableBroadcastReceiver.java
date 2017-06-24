package md5e0c8df6e6e221d5c163c41bc679a7531;


public class ObservableBroadcastReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("Plugin.BluetoothLE.Internals.ObservableBroadcastReceiver, Plugin.BluetoothLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ObservableBroadcastReceiver.class, __md_methods);
	}


	public ObservableBroadcastReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ObservableBroadcastReceiver.class)
			mono.android.TypeManager.Activate ("Plugin.BluetoothLE.Internals.ObservableBroadcastReceiver, Plugin.BluetoothLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
