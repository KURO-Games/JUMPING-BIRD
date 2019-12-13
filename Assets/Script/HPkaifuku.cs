using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPkaifuku : MonoBehaviour
{
    
    float timer_f = 0f;
    int timer_i = 0;

    void Kaifuku()
    {
        if (Bird.Instance.Life < 3 && Bird.Instance.Life > 0)
        {
            if (timer_i == 8)
            {
                timer_f = 0;
                Bird.Instance.Life += 1;
                Debug.Log("+1");
            }
        }
        if (Bird.Instance.Life == 3)
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
            if (Bird.Instance.Attack == false)
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
