using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject Bird;


    Vector3 offset;
    void Start()
    {
        Bird = GameObject.Find("Bird");

    }
    void Update()
    {
        if (Bird.GetComponent<Bird>().Fly == true)
        {
            if (Bird.transform.position.y >= 2)
            {
                transform.position = new Vector3(Bird.transform.position.x + 3f, Bird.transform.position.y - 2, -10);
            }
            else transform.position = new Vector3(Bird.transform.position.x + 3f, 0, -10);
        }
    }
}