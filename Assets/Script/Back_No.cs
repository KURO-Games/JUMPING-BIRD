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
        GoTitle.gameObject.transform.position = new Vector2(424, -636);
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }
}
