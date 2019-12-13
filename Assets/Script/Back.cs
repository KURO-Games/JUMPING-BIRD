using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject GoTitle;

    void Start()
    {
        GoTitle = GameObject.Find("GoTitle");
        GoTitle.gameObject.SetActive(false);
    }

    public void OnClick()
    {
        GoTitle.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

}
