using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPkaifuku : MonoBehaviour
{
    public GameObject Bird;
    float timer_f = 0f;
    int timer_i = 0;

    void Start()
    {
        Bird = GameObject.Find("Bird");
    }

    void Kaifuku()
    {
        if (Bird.GetComponent<Bird>().Life < 3 && Bird.GetComponent<Bird>().Life > 0)
        {
            if (timer_i == 8)
            {
                timer_f = 0;
                Bird.GetComponent<Bird>().Life += 1;
                Debug.Log("+1");
            }
        }
        if (Bird.GetComponent<Bird>().Life == 3)
        {
            if (timer_i == 8)
            {
                timer_f = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Rock")
        {
            if (Bird.GetComponent<Bird>().Attack == false)
            {
                timer_f = 0;
            }
        }
    }

    void Update()
    {
        timer_f += Time.deltaTime;
        timer_i = (int)timer_f;
        Kaifuku();
    }
}
