package md5e0c8df6e6e221d5c163c41bc679a7531;


public class LollipopScanCallback
	extends android.bluetooth.le.ScanCallback
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScanResult:(ILandroid/bluetooth/le/ScanResult;)V:GetOnScanResult_ILandroid_bluetooth_le_ScanResult_Handler\n" +
			"";
		mono.android.Runtime.register ("Plugin.BluetoothLE.Internals.LollipopScanCallback, Plugin.BluetoothLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LollipopScanCallback.class, __md_methods);
	}


	public LollipopScanCallback () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LollipopScanCallback.class)
			mono.android.TypeManager.Activate ("Plugin.BluetoothLE.Internals.LollipopScanCallback, Plugin.BluetoothLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onScanResult (int p0, android.bluetooth.le.ScanResult p1)
	{
		n_onScanResult (p0, p1);
	}

	private native void n_onScanResult (int p0, android.bluetooth.le.ScanResult p1);

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
