using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_IOS
using System.Runtime.InteropServices;
#endif

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleMgr : MonoBehaviour
{
#if UNITY_IOS
    [DllImport("__Internal")]
    static extern string GetBundleVersion();
#endif
    bool Tap;
    [SerializeField]
    Text version;
    [SerializeField]
    string verstr;
    // Start is called before the first frame update
    void Start()
    {
        if (verstr != "")
            version.text = "Ver: " + verstr + "." + Application.version + "." + GetBuildNumber();
        else
            version.text = "Ver: " + Application.version + "." + GetBuildNumber();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Tap)
        {
            Tap = true;
            SceneLoadManager.LoadScene("Game");
        }
    }
    public static string GetBuildNumber()
    {
        #if UNITY_EDITOR
            return PlayerSettings.iOS.buildNumber;
        #elif UNITY_IOS
            return GetBundleVersion();
        #else
            return null;
        #endif
    }

}
