using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class MyMainCameraScript : MonoBehaviour 
{

#if UNITY_ANDROID
    [DllImport("mobileapptracker")]
    private static extern void initNativeCode(string advertiserId, string conversionKey);
    [DllImport("mobileapptracker")]
    private static extern void trackSession();
#endif

#if UNITY_IPHONE
    [DllImport ("__Internal")] 
    private static extern void initNativeCode(string advertiserId, string conversionKey);
    [DllImport ("__Internal")] 
    private static extern void trackSession();
#endif

	void Start()
	{
        //initNativeCode("6058", "d4117f5c29d50d3ae29cf7d89b70f8b3");
        //trackSession();
        MATBinding.Init("6058", "d4117f5c29d50d3ae29cf7d89b70f8b3");
        MATBinding.MeasureSession();
        MATBinding.MeasureAction("Open");
	}
}
