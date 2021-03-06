﻿  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingColiderAnimator : MonoBehaviour
{
    enum BoxColiders
    {
        BuildingLeft,
        BuildingRight,
        BuildingUnder
    }

    [SerializeField, Header("アニメーション")]
    GameObject Building;
    [SerializeField, Header("ビルBoxColider設定")]
    BoxColiders BoxColiderChoice;

    private float mLength;
    private float mCur;
    private bool destroy;
    private void Start()
    {
        Animator _animOne = Building.GetComponent<Animator>();
        AnimatorStateInfo infAnim = _animOne.GetCurrentAnimatorStateInfo(0);
        mLength = infAnim.length;
        mCur = 0;
    }
    private void Update()
    {
        if (!destroy)
            return;
        mCur += Time.deltaTime;
        if (mCur > mLength)
        {
            Destroy(Building);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogWarning(collision.name+" "+collision.tag);
        if (collision.tag == "Bird")
        {
            destroy = true;
            SoundManager.Instance.PlaySe(SE.AttackBuilding);
            Building.GetComponent<Animator>().SetTrigger(BoxColiderChoice.ToString());
            Bird.Instance.BuildingPos = this.gameObject.transform.position;
            Bird.Instance.CrashBuilding = true;
            //360度をSPゲージのMAX値である20で割り、それを3ポイント分加算
            SPGimick.Instance.Gauge.fillAmount += (1f / 20f) * 3f;
        }
        else
        {
            return;
        }
    }

}
