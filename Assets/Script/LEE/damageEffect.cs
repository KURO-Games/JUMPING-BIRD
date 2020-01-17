using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageEffect : MonoBehaviour
{
    private CanvasGroup canvas;

    [SerializeField, Range(0, 1)]
    private float A_Start;

    [SerializeField, Range(0, 1)]
    private float A_End;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (A_Start <= 1)
        {
            canvas.alpha = A_Start + Time.deltaTime;
        }

        else
        {

        }
        
        
    }
}
