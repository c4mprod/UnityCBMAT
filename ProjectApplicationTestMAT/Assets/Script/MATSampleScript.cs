using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Chartboost;

public class MATSampleScript : MonoBehaviour
{

#if UNITY_ANDROID || UNITY_IPHONE
    string MAT_ADVERTISER_ID = null;
    string MAT_CONVERSION_KEY = null;
    //string MAT_PACKAGE_NAME = "com.hasoffers.unitytestapp";
    string MAT_SITE_ID = null;
#endif

    void Awake()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        MAT_ADVERTISER_ID = "6058";
        MAT_CONVERSION_KEY = "d4117f5c29d50d3ae29cf7d89b70f8b3";
#if UNITY_ANDROID
        //MAT_SITE_ID = "52048";
#elif UNITY_IPHONE
		MAT_SITE_ID = "52096";
#endif
        Debug.Log("Awake called: " + MAT_ADVERTISER_ID + ", " + MAT_CONVERSION_KEY + ", " + MAT_SITE_ID);
#endif

     //   MATBinding.SetUserId("UA-52920566-1");
        if (GoogleAnalytics.instance)
            GoogleAnalytics.instance.LogScreen("Main Menu");
        return;
    }

    void OnGUI()
    {
        GUIStyle headingLabelStyle = new GUIStyle();
        headingLabelStyle.fontStyle = FontStyle.Bold;
        headingLabelStyle.fontSize = 50;
        headingLabelStyle.alignment = TextAnchor.MiddleCenter;
        headingLabelStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 5, Screen.width - 20, 90), "MAT Unity Test App", headingLabelStyle);

        GUI.skin.button.fontSize = 40;

        if (GUI.Button(new Rect(10, 110, Screen.width - 20, 90), "Start MAT"))
        {
            Debug.Log("Start MAT clicked");
#if UNITY_ANDROID || UNITY_IPHONE
            MATBinding.Init(MAT_ADVERTISER_ID, MAT_CONVERSION_KEY);

#if UNITY_IPHONE
			MATBinding.SetAppleAdvertisingIdentifier(iPhone.advertisingIdentifier, iPhone.advertisingTrackingEnabled);
#endif
#endif
        }

        else if (GUI.Button(new Rect(10, 210, Screen.width - 20, 90), "Measure Session"))
        {
            Debug.Log("Measure Session clicked");
#if UNITY_ANDROID || UNITY_IPHONE
            MATBinding.MeasureSession();
#endif
        }

        else if (GUI.Button(new Rect(10, 310, Screen.width - 20, 90), "Measure Action ?"))
        {
            Debug.Log("Measure Action clicked");
#if UNITY_ANDROID || UNITY_IPHONE
            MATBinding.MeasureAction("evt11");
            MATBinding.MeasureActionWithRefId("evt12", "ref111");
            MATBinding.MeasureActionWithRevenue("evt13", 0.35, "CAD", "ref111");
#endif
        }

        else if (GUI.Button(new Rect(10, 410, Screen.width - 20, 90), "Measure Action Install"))
        {
            Debug.Log("Measure Action clicked");
#if UNITY_ANDROID || UNITY_IPHONE
            MATBinding.MeasureAction("Install");
#endif
        }

        else if (GUI.Button(new Rect(10, 510, Screen.width - 20, 90), "Measure Action Open"))
        {
            Debug.Log("Measure Action clicked");
#if UNITY_ANDROID || UNITY_IPHONE
            MATBinding.MeasureAction("Open");
#endif
        }
        else if (GUI.Button(new Rect(10, 610, Screen.width - 20, 90), "CB Show Commercial"))
        {
            Debug.Log("CB Show Commercial");
            CBBinding.showInterstitial(null);
        }
    }
}
