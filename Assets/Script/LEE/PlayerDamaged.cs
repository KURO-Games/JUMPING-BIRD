using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamaged : MonoBehaviour
{
    private Image image;
    [Range(0, 5), SerializeField]
    private float WaitTime = 0.5f;
    //[Range(1, 10), SerializeField]
    //private int fadeOutSpeed = 1;
    //private bool isDamaged;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        StartCoroutine("blink");

    }

    //IEnumerator fadeout()
    //{
    //    yield return new WaitUntil(() => Bird.Instance.isDamaged);
    //    float alpha = 1f;
    //    while (alpha > 0)
    //    {
    //        yield return new WaitForSeconds(0.1f);
    //        alpha -= Time.deltaTime * fadeOutSpeed;
    //        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

    //    }
    //    Bird.Instance.isDamaged = false;
    //    StartCoroutine("fadeout");
    //}

    IEnumerator blink ()
    {
        yield return new WaitUntil(() => Bird.Instance.isDamaged);
        //float alpha = 1f;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);

        yield return new WaitForSeconds(WaitTime);

        //alpha = 0;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);

        Bird.Instance.isDamaged = false;
        StartCoroutine("blink");
    }
}
