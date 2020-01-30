using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_YesNo : MonoBehaviour
{
    public GameObject GoTitle;
    [SerializeField]
    private GameObject Bird;
    [SerializeField]
    private GameObject SPIcon;

    void Start()
    {

    }
    public void OnClickYes()
    {
        SoundManager.Instance.FadeOutBgm(1);
        SceneLoadManager.LoadScene("Init");
        Time.timeScale = 1;
    }
    public void OnClickNo()
    {
        SoundManager.Instance.FadeOutBgm(1);
        GoTitle.gameObject.SetActive(false);
        Bird.GetComponent<BirdJumper>().enabled = true;
        SPIcon.GetComponent<CanvasGroup>().blocksRaycasts = true;
        Time.timeScale = 1;
    }
}
