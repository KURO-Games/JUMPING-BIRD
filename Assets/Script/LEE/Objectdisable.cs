using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectdisable : MonoBehaviour
{

    CanvasGroup canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<CanvasGroup>();
        canvas.blocksRaycasts = true;
        StartCoroutine("Enable");
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Enable()
    {
        yield return new WaitUntil(() => Bird.Instance.Die || Bird.Instance.isClear);
        canvas.blocksRaycasts = false;

    }
}
