using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_ColiderController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bird")
        {
           transform.GetChild(3).gameObject.SetActive(false);

            StartCoroutine("Delay");
        }
        else
        {
        
            return;
        }
    }

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Bird")
    //    {
    //        transform.GetChild(3).gameObject.SetActive(true);

    //    }
    //}

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.0f);
        transform.GetChild(3).gameObject.SetActive(true);

    }
}
