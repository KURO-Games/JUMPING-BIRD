using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectrumEffect : MonoBehaviour
{
    //private LineRenderer Line;
    private TrailRenderer Trail;

    [Range(0, 2)]
    public float D_TIme = 2;
    // Start is called before the first frame update
    void Start()
    {
        //Line = GetComponent<LineRenderer>();
        //Line.SetPosition(0, Bird.Instance.transform.position);

        Trail = GetComponent<TrailRenderer>();
        transform.position = Bird.Instance.transform.position;

        Trail.time = D_TIme / 4;
    }

    // Update is called once per frame
    void Update()
    {
        //Line.SetPosition(1, Bird.Instance.transform.position);
        //Destroy(gameObject, D_TIme);
        transform.position = Bird.Instance.transform.position;
        Destroy(gameObject,D_TIme);

    }
}
