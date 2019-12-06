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
    bool Tap;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Tap)
        {
            Tap = true;
            SceneLoadManager.LoadScene("Game");
        }
    }

}
