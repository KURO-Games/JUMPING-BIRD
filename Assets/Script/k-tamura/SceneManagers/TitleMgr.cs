using UnityEngine;
/// <summary>
/// TitleSceneManager 
/// </summary>
public class TitleMgr : MonoBehaviour
{
    bool Tap;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Tap)
        {
            Tap = true;
            SceneLoadManager.LoadScene("Game");
        }
    }

}
