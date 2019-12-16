using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScalControl : MonoBehaviour
{
    private Image image;
    [Range(1,5)]
    public float radius = 2.0f;
    [Range(0, 2)]
    public float Speed = 2.0f;
    [Range(0, 10)]
    public float Start_XY = 0;
    private float Scal_XY;

    public  Camera cam;
    public 

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        image = GetComponent<Image>();
        Scal_XY = Scal_XY  + Start_XY;
    }

    // Update is called once per frame
    void Update()
    {
        Scal_XY += (Time.deltaTime * Speed);
        Scal_XY %= radius;
        Debug.Log(Scal_XY);
        image.rectTransform.localScale = new Vector3(Scal_XY, Scal_XY, 0);
        //====================================================
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(image.rectTransform.position);
        Vector3 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);
        Debug.Log(screenPos);
    }
}
