package md5e0c8df6e6e221d5c163c41bc679a7531;


public class PreLollipopScanCallback
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.bluetooth.BluetoothAdapter.LeScanCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLeScan:(Landroid/bluetooth/BluetoothDevice;I[B)V:GetOnLeScan_Landroid_bluetooth_BluetoothDevice_IarrayBHandler:Android.Bluetooth.BluetoothAdapter/ILeScanCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Plugin.BluetoothLE.Internals.PreLollipopScanCallback, Plugin.BluetoothLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PreLollipopScanCallback.class, __md_methods);
	}


	public PreLollipopScanCallback () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PreLollipopScanCallback.class)
			mono.android.TypeManager.Activate ("Plugin.BluetoothLE.Internals.PreLollipopScanCallback, Plugin.BluetoothLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onLeScan (android.bluetooth.BluetoothDevice p0, int p1, byte[] p2)
	{
		n_onLeScan (p0, p1, p2);
	}

	private native void n_onLeScan (android.bluetooth.BluetoothDevice p0, int p1, byte[] p2);

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
