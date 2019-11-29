using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private Bird Bird;

    public GameObject Player;
    public GameObject BirdEffect;
    public GameObject CrashEffect;

    // Start is called before the first frame update
    void Start()
    {
        Bird = Player.GetComponent<Bird>();
    }

    // Update is called once per frame
    void Update()
    {
        EffectSet();
    }

    void EffectSet()
    {
        if (Bird.isEffect)
        {
            Instantiate(CrashEffect, Bird.transform.position, Quaternion.identity);
            Instantiate(BirdEffect, Bird.transform.position, Quaternion.identity);
            Bird.isEffect = false;
        }
    }
}
