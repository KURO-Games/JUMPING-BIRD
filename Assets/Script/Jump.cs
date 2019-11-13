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
        if (Bird.GetComponent<Bird>().FirstJumpOver == true)
        {
            if (Bird.GetComponent<Bird>().Attack == false)
            {
                if (Bird.GetComponent<Bird>().MouseInBird == true && Input.GetMouseButtonDown(0))
                {
                    Instantiate(Finger, new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,-5f) ,Quaternion.identity);
                    Bird.GetComponent<Bird>().MousePush = true;
                    GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }
        }
    }
}
