using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haikei : MonoBehaviour
{
    public GameObject Bird;
    float size = 26.6f;
    void Start()
    {
        Bird = GameObject.Find("Bird");
    }

    
    void Update()
    {
        if(gameObject.transform.position.x < Bird.transform.position.x - size)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + size*2, gameObject.transform.position.y,9);
        }
    }
}
