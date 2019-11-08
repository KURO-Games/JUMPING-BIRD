using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haikei : MonoBehaviour
{
    public GameObject Bird;
    void Start()
    {
        Bird = GameObject.Find("Bird");
    }

    
    void Update()
    {
        if(gameObject.transform.position.x < Bird.transform.position.x-30.7f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 61.4f, gameObject.transform.position.y,9);
        }
    }
}
