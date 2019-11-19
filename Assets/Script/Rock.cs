using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject Bird;
    public Vector2 BirdTransform;

    void Start()
    {
        Bird = GameObject.Find("Bird");
        BirdTransform = Bird.transform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, BirdTransform, Time.deltaTime * 5);
        if(transform.position.x == BirdTransform.x && transform.position.y == BirdTransform.y)
        {
            Destroy(this.gameObject);
        }
    }
}
