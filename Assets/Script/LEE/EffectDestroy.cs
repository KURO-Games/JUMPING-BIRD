using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{

    private ParticleSystem Particle;
    private float D_Time; 
    
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        Particle = GetComponent <ParticleSystem>();
        D_Time = Particle.main.duration * 2; //エラー例外
        Destroy(gameObject, D_Time);
    }

    // Update is called once per frame
    void Update()
    {
    }

}
