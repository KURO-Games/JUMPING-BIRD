using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_YesNo : MonoBehaviour
{
    public GameObject GoTitle;

    void Start()
    {
        GoTitle = GameObject.Find("GoTitle");
    }
    public void OnClickYes()
    {
        SoundManager.Instance.FadeOutBgm(1);
        SceneLoadManager.LoadScene("Title");
        Time.timeScale = 1;
    }
    public void OnClickNo()
    {
        SoundManager.Instance.FadeOutBgm(1);
        GoTitle.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
