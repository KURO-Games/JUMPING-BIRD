using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
[DisallowMultipleComponent]
public class BirdAnimationController : SingletonMonoBehaviour<BirdAnimationController>
{
    private Animator _anim;
    private void Start()
    {
        _anim = this.gameObject.GetComponent<Animator>();
    }
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

    public static void BirdAnimations(BirdAnimParam _BirdAnimParam)
    {
        Instance._anim.SetInteger("", (int)_BirdAnimParam);
    }
}
