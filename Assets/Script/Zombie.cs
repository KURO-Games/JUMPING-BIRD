using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject Bird;
    void Start()
    {
        Bird = GameObject.Find("Bird");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector2(Bird.transform.position.x,-2.8f), Time.deltaTime);
    }
}
