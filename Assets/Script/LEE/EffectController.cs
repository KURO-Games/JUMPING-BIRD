﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    //private Bird Bird;

    //public GameObject Player;
    [Header("エフェクト種類"),SerializeField]
    private GameObject StarEffectSub,StarEffectMain,DestroyEffect_Z,DestroyEffect_B;
    [Header("必殺技の時出る鳥の残像"), SerializeField]
    private GameObject SpectrumEffect;
    [Header("必殺技の攻撃Effect(円)"), SerializeField]
    private GameObject SkillEffect;

    // Start is called before the first frame update
    void Start()
    {
        //Bird = Player.GetComponent<Bird>();
        
    }

    // Update is called once per frame
    void Update()
    {
        EffectSet();
            //Debug.Log(Bird.Instance.transform.position);
    }

    void EffectSet()
    {
        if (Bird.Instance.CrashBuilding)
        {
            Instantiate(StarEffectMain, Bird.Instance.bird().transform.position, Quaternion.identity);
            Instantiate(DestroyEffect_B, Bird.Instance.BuildingPos, Quaternion.identity);
            Instantiate(StarEffectSub, Bird.Instance.bird().transform.position, Quaternion.identity);
            Bird.Instance.CrashBuilding = false;
        }

        else if (Bird.Instance.CrashZombie)
        {
            Instantiate(DestroyEffect_Z, Bird.Instance.ZombiePos, Quaternion.identity);
            Bird.Instance.CrashZombie = false;
        }

        else if (SPGimick.Instance.SpectrumEffect) //追加 イゴンヒ
        {
            Instantiate(SpectrumEffect);
            SPGimick.Instance.SpectrumEffect = false;
        }

        else if(SPGimick.Instance.SpecuakSkill && Bird.Instance.transform.position.y <= -3)//追加 イゴンヒ
        {
            Instantiate(SkillEffect);
            SPGimick.Instance.SpecuakSkill = false;
        }
    }   
}