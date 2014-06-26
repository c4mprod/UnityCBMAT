using UnityEngine;
using System.Collections;
using Chartboost;	

public class HandlerCB : MonoBehaviour 
{
    private float m_time = 0.0f;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void OnEnable()
    {
        // Initialize the Chartboost plugin
#if UNITY_ANDROID
        CBBinding.init("53a852b4c26ee44a28aa9321", "37134b658212ce1352566ed23017ed2d1f7d5771");
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
}
