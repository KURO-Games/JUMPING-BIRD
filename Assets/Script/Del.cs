using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del : MonoBehaviour
{
    public GameObject Bird;
    void Start()
    {
        Bird = GameObject.Find("Bird");
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (gameObject.transform.position.x < Bird.transform.position.x - 10)
        {
            Destroy();
        }

    }
}
