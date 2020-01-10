using UnityEngine;
/// <summary>
/// TitleSceneManager 
/// </summary>
public class TitleMgr : MonoBehaviour
{
    bool Tap;
    private void Start()
    {
        SoundManager.PlayBgm(BGM.Title);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Tap)
        {
            SoundManager.Instance.FadeOutBgm(2);
            Tap = true;
            SceneLoadManager.LoadScene("Game");
        }
    }

}
