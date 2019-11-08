﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDel : MonoBehaviour
{
    public GameObject Bird;
    void Start()
    {
        Bird = GameObject.Find("Bird");
        Invoke("Del", 10f);
    }

    void Del()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (gameObject.transform.position.x == Bird.transform.position.x - 10)
        {
            Del();
        }

    }
}
