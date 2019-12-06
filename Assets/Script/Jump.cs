using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Finger;
    
    void Start()
    {
        Bird = GameObject.Find("Bird");
    }

    void Update()
    {
        if (Bird.GetComponent<Bird>().FirstJumpOver)
        {            
            if (!Bird.GetComponent<Bird>().Attack)
            {
                if (Bird.GetComponent<Bird>().MouseInBird && Input.GetMouseButtonDown(0))
                {
                    Instantiate(Finger, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-5f) ,Quaternion.identity);
                    Bird.GetComponent<Bird>().MousePush = true;
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }
        }
    }
}
