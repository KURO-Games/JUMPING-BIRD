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
                    Instantiate(Finger, gameObject.transform.position, Quaternion.identity);
                    Bird.GetComponent<Bird>().MousePush = true;
                }
            }
        }
    }
}
