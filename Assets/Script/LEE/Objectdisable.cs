using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectdisable : MonoBehaviour
{
    [SerializeField]
    GameObject Target;
    [SerializeField]
    GameObject Target2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Enable");
        Target.gameObject.SetActive(false);
        Target2.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Enable()
    {
        yield return new WaitUntil(() => Bird.Instance.Die);
        Target.gameObject.SetActive(true);
        Target2.gameObject.SetActive(true);
    }
}
