using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private GameObject GoTitle;

    void Start()
    {
        //GoTitle.gameObject.SetActive(false);        
    }

    public void OnClick()
    {        
        SoundManager.Instance.PlayBgm(BGM.Settings);
        GoTitle.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
