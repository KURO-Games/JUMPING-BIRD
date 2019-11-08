using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Bird;


    Vector3 offset;
    void Start()
    {
        Bird = GameObject.Find("Bird");

    }
    void Update()
    {
        if (Bird.GetComponent<Bird>().Fly == true)
        {
            transform.position = new Vector3(Bird.transform.position.x + 3f, 0, -10);
        }
    }
}