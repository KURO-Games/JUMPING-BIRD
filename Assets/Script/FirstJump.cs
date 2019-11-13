using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstJump : MonoBehaviour
{
    public GameObject Bird;
    void Start()
    {
        Bird = GameObject.Find("Bird");
    }

    void Update()
    {
        if (Bird.GetComponent<Bird>().MouseInBird == true && Input.GetMouseButtonDown(0))
        {
            Bird.GetComponent<Bird>().MousePush = true;
        }

        if (Bird.GetComponent<Bird>().MousePush == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            transform.position = mousePos;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (Bird.GetComponent<Bird>().MousePush == true && Input.GetMouseButtonUp(0))
        {
            Bird.GetComponent<Bird>().MousePush = false;
            Bird.GetComponent<Bird>().Fly = true;
            Bird.GetComponent<Bird>().Attack = true;
            Bird.GetComponent<Bird>().FirstJumpOver = true;
            Destroy(this);
        }

    }
}
