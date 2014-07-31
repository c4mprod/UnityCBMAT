using UnityEngine;
using System.Collections;
using Chartboost;

public class HandlerCB : MonoBehaviour
{
    private float m_time = 0.0f;

    void Start()
    {
    }

    void OnEnable()
    {
        // Initialize the Chartboost plugin
#if UNITY_ANDROID
        CBBinding.init("53b6be3b89b0bb7eabde72f5", "f33677d22df1fb5e13c67cedc9eb686d6922d695");
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
