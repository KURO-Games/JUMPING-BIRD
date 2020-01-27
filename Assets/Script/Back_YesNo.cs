using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_YesNo : MonoBehaviour
{
    [SerializeField]
    private GameObject GoTitle;
    [SerializeField]
    private GameObject Button;

    void Start()
    {
        GoTitle = GameObject.Find("GoTitle");
    }
    public void OnClickYes()
    {
        SoundManager.Instance.FadeOutBgm(1);
        SceneLoadManager.LoadScene("Title");
        GoTitle.gameObject.SetActive(false);
        Button.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnClickNo()
    {
        SoundManager.Instance.FadeOutBgm(1);
        GoTitle.gameObject.SetActive(false);
        Button.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

}
