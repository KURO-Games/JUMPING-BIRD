using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    public GameObject GoTitle;

    void Start()
    {
        GoTitle = GameObject.Find("GoTitle");
    }

    public void OnClick()
    {
        GoTitle.gameObject.transform.position = new Vector2(424, 318);
        Time.timeScale = 0;
    }

}
