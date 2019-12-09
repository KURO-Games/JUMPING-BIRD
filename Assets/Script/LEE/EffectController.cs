using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private Bird Bird;

    public GameObject Player;
    public GameObject StarEffectSub;
    public GameObject StarEffectMain;
    public GameObject DestroyEffect_Z;
    public GameObject DestroyEffect_B;


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
        if (Bird.CrashBuilding)
        {
            Instantiate(StarEffectMain, Bird.transform.position, Quaternion.identity);
            Instantiate(DestroyEffect_B, Bird.BuildingPos, Quaternion.identity);
            Instantiate(StarEffectSub, Bird.transform.position, Quaternion.identity);
            Bird.CrashBuilding = false;
        }

        else if (Bird.CrashZombie)
        {
            Instantiate(DestroyEffect_Z, Bird.ZombiePos, Quaternion.identity);
            Bird.CrashZombie = false;
        }
    }   
}