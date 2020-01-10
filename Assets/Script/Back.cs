using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField]
    private GameObject GoTitle;

    void Start()
    {
        //GoTitle.gameObject.SetActive(false);        
    }

    public void OnClick()
    {        
        SoundManager.PlayBgm(BGM.Settings);
        GoTitle.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
