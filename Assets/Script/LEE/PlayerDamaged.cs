using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamaged : MonoBehaviour
{
    private Image image;
    [Range(1, 10), SerializeField]
    private int fadeOutSpeed = 1;
   
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine("fadeout");
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator fadeout ()
    {
        float alpha = 1f;
        while(alpha >= 0)
        {
            yield return new WaitForSeconds(0.1f);
            alpha -= Time.deltaTime * fadeOutSpeed;
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
        }
        
    }
}
