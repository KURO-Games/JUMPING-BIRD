using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private GameObject GoTitle;
    [SerializeField]
    private GameObject SPIcon;

    CanvasGroup canvas;

    void Start()
    {
        //GoTitle.gameObject.SetActive(false);        
        canvas = GetComponent<CanvasGroup>();
        canvas.blocksRaycasts = true;
        StartCoroutine("Enable");
    }

    public void OnClick()
    {        
        SoundManager.PlayBgm(BGM.Settings);
        GoTitle.gameObject.SetActive(true);
        Time.timeScale = 0;
        Bird.Instance.GetComponent<BirdJumper>().enabled = false;
        SPIcon.GetComponent<CanvasGroup>().blocksRaycasts = false;
        
    }

    IEnumerator Enable()
    {
        yield return new WaitUntil(() => Bird.Instance.Die);
        canvas.blocksRaycasts = false;

    }

}
