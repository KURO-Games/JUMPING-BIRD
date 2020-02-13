using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_ColiderController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
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

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(3).gameObject.SetActive(true);

    }
}
