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
    }
    /// <summary>
    /// BirdAnimation一覧(Enum)
    /// </summary>
    public enum BirdAnimParam
    {
        Flying,
        Fall,
        Flyup,
        HitsStone,
        Ricochet,
        Swoop,
        ZonbieHit,
    }
    /// <summary>
    /// BirdAnimation再生
    /// </summary>
    /// <param name="_BirdAnimParam">BirdAnimParam(Enum)</param>
    public static void BirdAnimations(BirdAnimParam _BirdAnimParam)
    {
        Instance._anim.SetInteger("", (int)_BirdAnimParam);
    }
}
