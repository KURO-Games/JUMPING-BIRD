﻿using System.Collections;
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
        //canvas = GetComponent<CanvasGroup>();
        //canvas.blocksRaycasts = true;
    //    StartCoroutine("Enable");
    //    StartCoroutine("goToTitle");
    }

    //public void OnClick()
    //{        
    //    SoundManager.PlayBgm(BGM.Settings);
    //    GoTitle.gameObject.SetActive(true);
    //    Time.timeScale = 0;
    //    BirdJumper.Instance.GetComponent<BirdJumper>().enabled = false;
    //    SPIcon.GetComponent<CanvasGroup>().blocksRaycasts = false;

    //}

    /*------------------------------------------イゴンヒ-------------------------------------*/

    private void Update()
    {
        if(MultyInput())
        {
            SoundManager.PlayBgm(BGM.Settings);
            GoTitle.gameObject.SetActive(true);
            Time.timeScale = 0;
            Bird.Instance.GetComponent<BirdJumper>().enabled = false;
            SPIcon.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

    }

    private bool MultyInput()
    {
        if (Input.touchCount == 2 && !Bird.Instance.Die
                                  && !SPGimick.Instance.SPGimickStart
                                  && !Bird.Instance.isClear)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                return true;
            }
        }
        return false;
    }

    

    IEnumerator goToTitle()
    {
        yield return new WaitUntil(() => MultyInput() || !Bird.Instance.Die);
        SoundManager.PlayBgm(BGM.Settings);
        GoTitle.gameObject.SetActive(true);
        Time.timeScale = 0;
        Bird.Instance.GetComponent<BirdJumper>().enabled = false;
        SPIcon.GetComponent<CanvasGroup>().blocksRaycasts = false;
        StartCoroutine("goToTitle");

    }
    /*------------------------------------------イゴンヒ-------------------------------------*/
}