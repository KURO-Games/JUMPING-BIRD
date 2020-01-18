using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
[DisallowMultipleComponent]
public class BirdAnimationController : SingletonMonoBehaviour<BirdAnimationController>
{

    private Animator _anim;
    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        _anim = this.gameObject.GetComponent<Animator>();
        birdAnimParam = BirdAnimParam.Normal;
    }
    /// <summary>
    /// BirdAnimation一覧(Enum)
    /// </summary>
    public enum BirdAnimParam
    {
        Normal,//0
        FlyUp,//1
        NormalFeather,//2
        Swoop,//3
        HitStone,//4
        Ricochet,//5
        Fall,//6
        ZonbieHit,//7
    }
    public BirdAnimParam birdAnimParam;
    /// <summary>
    /// BirdAnimation再生
    /// </summary>
    /// <param name="_BirdAnimParam">BirdAnimParam(Enum)</param>
    public static void BirdAnimations(BirdAnimParam _BirdAnimParam)
    {
        //Debug.Log("num:"+(int)_BirdAnimParam +":"+ _BirdAnimParam);
        Instance._anim.SetInteger("BirdParam", (int)_BirdAnimParam);
    }
}
