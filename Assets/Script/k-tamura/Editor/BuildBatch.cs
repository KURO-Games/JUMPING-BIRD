using UnityEngine;
using UnityEditor;
#if UNITY_IOS
 using UnityEditor.iOS.Xcode;
#endif
using UnityEditor.Callbacks;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

public class BuildBatch : MonoBehaviour
{

#if UNITY_IOS
     // iOSのTestFlightで「輸出コンプライアンスの確認」の設定チェックの回避
     [PostProcessBuild]
     public static void ChangeXcodePlist(BuildTarget buildTarget, string pathToBuiltProject)
     {
         if (buildTarget == BuildTarget.iOS)
         {
             string plistPath = pathToBuiltProject + "/Info.plist";
             var plist = new PlistDocument();
             plist.ReadFromString(File.ReadAllText(plistPath));
 
             var rootDict = plist.root;
             rootDict.SetString("ITSAppUsesNonExemptEncryption", "false");
 
             File.WriteAllText(plistPath, plist.WriteToString());
         }
     }
#endif
}