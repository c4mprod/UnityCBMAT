using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using MiniJSON;


public class ServerHandler : MonoBehaviour
{
    public WWW m_Fetchwww;
    public GameObject m_button;
    public Sprite m_Sprite;
    Hashtable m_Header;
    private string m_id = null;
    private ParsedData.Type m_Type = ParsedData.Type.NONE;
    private List<ParsedData> m_ParsedList = new List<ParsedData>();


    void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        AndroidJavaClass clsUnity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = clsUnity.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaObject objResolver = objActivity.Call<AndroidJavaObject>("getContentResolver");
        AndroidJavaClass clsSecure = new AndroidJavaClass("android.provider.Settings$Secure");
        m_id = clsSecure.CallStatic<string>("getString", objResolver, "android_id");
        Debug.Log("ID : " + m_id);
#endif

        m_Header = new Hashtable();
        m_Header.Add("Content-Type", "application/json");

        StartCoroutine("LaunchRequest");
    }

    IEnumerator LaunchRequest()
    {
        m_Fetchwww = new WWW("http://chartboost-relay.herokuapp.com/fetch?uuid=" + m_id, null, m_Header);
        yield return m_Fetchwww;

        //Parse the request
        List<object> json = Json.Deserialize(m_Fetchwww.text) as List<object>;
      
        //Put the desired datas in a specific list of ParsedData
        foreach (Dictionary<string, object> element in json)
        {
            m_ParsedList.Add(new ParsedData((string)element["uuid"], (string)element["type"]));
        }

        foreach (ParsedData obj in m_ParsedList)
        {
            if (m_Type != ParsedData.Type.INSTALL)
            {
                m_Type = obj.getType();
            }
        }

        m_button.GetComponent<SpriteRenderer>().sprite = m_Sprite;
        if (m_Type == ParsedData.Type.CLICK)
        {
            UnityEngine.Debug.Log("click");
            m_button.GetComponent<SpriteRenderer>().color = new Color(1.000f, 0.498f, 0.153f);
        }
        else if (m_Type == ParsedData.Type.INSTALL)
        {
            UnityEngine.Debug.Log("install");
            m_button.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else
        {
            UnityEngine.Debug.Log("none");
            m_button.GetComponent<SpriteRenderer>().color = Color.red;
        }
        Debug.Log(m_Fetchwww.text);
        yield return null;
    }

    void OnGUI()
    {
        GUI.skin.textField.fontSize = 25;
        m_id = GUI.TextField(new Rect(30, Screen.height / 2.0f + 100, 695, 30), m_id);
    }
}
