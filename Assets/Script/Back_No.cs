using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_No : MonoBehaviour
{
    public GameObject GoTitle;

    void Start()
    {
        GoTitle = GameObject.Find("GoTitle");
    }

    public void OnClick()
    {
        GoTitle.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
