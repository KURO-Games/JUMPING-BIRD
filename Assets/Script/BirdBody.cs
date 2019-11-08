using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBody : MonoBehaviour
{
    public GameObject Bird;
    void Start()
    {
        Bird = GameObject.Find("Bird");
    }

    void Update()
    {
        gameObject.transform.position = Bird.transform.position;
    }
}
