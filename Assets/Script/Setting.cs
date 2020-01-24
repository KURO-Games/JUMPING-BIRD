using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField]
    private GameObject GoTitle;
    [SerializeField]
    private GameObject Bird;

    void Start()
    {
        //GoTitle.gameObject.SetActive(false);        
    }

    public void OnClick()
    {        
        SoundManager.PlayBgm(BGM.Settings);
        GoTitle.gameObject.SetActive(true);
        Time.timeScale = 0;
        Bird.GetComponent<BirdJumper>().enabled = false;
    }
  


}
