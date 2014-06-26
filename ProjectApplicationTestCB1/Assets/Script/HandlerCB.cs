using UnityEngine;
using System.Collections;
using Chartboost;	

public class HandlerCB : MonoBehaviour 
{
    void OnEnable()
    {
        // Initialize the Chartboost plugin
#if UNITY_ANDROID
        // Replace these with your own Android app ID and signature from the Chartboost web portal

        CBBinding.init("539826adc26ee443febf0873", "35d4f35541196fb75fe27deabd28fbe66bf9fc28");
#elif UNITY_IPHONE
        // Replace these with your own iOS app ID and signature from the Chartboost web portal
        CBBinding.init("CB_APP_ID_IOS", "CB_APP_SIG_IOS");
#endif
    }

#if UNITY_ANDROID
    void OnApplicationPause(bool paused)
    {
        // Manage Chartboost plugin lifecycle
        CBBinding.pause(paused);
    }

    void OnDisable()
    {
        // Shut down the Chartboost plugin
        CBBinding.destroy();
    }
#endif

#if UNITY_ANDROID
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (CBBinding.onBackPressed())
                return;
            else
                Application.Quit();
        }
    }
#endif
    void OnGUI()
    {
#if UNITY_ANDROID
        // Disable user input for GUI when impressions are visible
        // This is only necessary on Android if we have disabled impression activities
        //   by having called CBBinding.init(ID, SIG, false), as that allows touch
        //   events to leak through Chartboost impressions
        GUI.enabled = !CBBinding.isImpressionVisible();
#endif

        GUI.skin.button.fontSize = 25;
        if (GUI.Button(new Rect(Screen.width / 2.0f - 150, Screen.height / 2.0f - 100, 300, 200), "Show Commercial"))
        {
            //This Function display the advertisement when called.
            Debug.Log("TEST TOUCH");
            CBBinding.showInterstitial(null);
        }
    }

    
}
