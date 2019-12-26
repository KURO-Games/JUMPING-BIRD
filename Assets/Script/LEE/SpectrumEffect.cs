using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumEffect : MonoBehaviour
{
    private LineRenderer Line;
    Vector3 DrawLine = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        Line = GetComponent<LineRenderer>();
        Line.SetPosition(0, Bird.Instance.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        Line.SetPosition(1, Bird.Instance.transform.position);
    }
}
