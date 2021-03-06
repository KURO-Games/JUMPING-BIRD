﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPGimick : SingletonMonoBehaviour<SPGimick>
{
    [SerializeField]
    private GameObject _zombie;
    [SerializeField]
    private Image birdIcon;
    private Color iconColor;

    //必殺技のゲージ
    public Image Gauge;

    //必殺技が使える状態か
    private bool SPBool = false;

    //必殺技が終わるまでボタンを連打出来ないようにする
    private bool doOnceSP = true;

    //必殺技の時に鳥と矢印を固定する場所
    public GameObject SPPos;

    //強く引っ張れのUI
    [SerializeField]
    private Image hippareUI;
    //Go!!のUI
    public Image goUI;

    //必殺技で下に飛ばす時の速さ
    [SerializeField]
    private float SPSpeed;

    private bool buttonPushFlag;

    //必殺技中か
    [HideInInspector]
    public bool SPGimickStart;

    //ゾンビの親オブジェクトの定義
    [SerializeField]
    private Transform zombieParent;

    //鳥の位置
    private Vector2 birdPos;

    //必殺技を出していいか
    [HideInInspector]
    public bool HissatsuFlag;
    private bool rePosBool;

    [SerializeField]
    private GameObject SPEffect_Star;
    [SerializeField]
    private GameObject SPEffect_OutLine;
    [SerializeField]
    private GameObject SPEffect_InLine;
    public bool pushes = false;

    public bool SpectrumEffect; //鳥の残像発生 
    public bool SpecuakSkill;
    public CanvasGroup iconCanGroup;

    void Start()
    {
        iconColor = birdIcon.color;
        //Gauge.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //必殺の技が発動し鳥がの速度が地面に当たったらゾンビが消える
        DestroyChildObject(zombieParent);　//イゴンヒ

        if (Gauge.fillAmount == 1f && doOnceSP)
        {
            SoundManager.Instance.PlaySe(SE.SPReady);
            SPEffect_Star.SetActive(true);
            SPEffect_OutLine.SetActive(true);
            SPEffect_InLine.SetActive(true);
            doOnceSP = false;
            //Debug.Log("GaugeMax");
            //アイコンの明るさをMAXにする
            iconColor.a = 1;
            birdIcon.color = iconColor;
            SPBool = true;
        }

        if (SPGimickStart && !rePosBool)
        {
            Bird.Instance.bird().transform.position = birdPos;

            //必殺技の関数を実行
            SPmain();
        }
    }
    public void HissatsuWaza()
    {
        if (SPBool && !Bird.Instance.cantSPBool)
        {
            BeforeSPBool();

            //必殺技ゲージを0にする
            Gauge.fillAmount = 0;
            SPEffect_Star.SetActive(false);
            SPEffect_OutLine.SetActive(false);
            SPEffect_InLine.SetActive(false);

            //SPアイコンのa値を半分にする
            iconColor.a = 0.5f;
            birdIcon.color = iconColor;

            //鳥が画面の真上に来る処理
            Bird.Instance.bird().transform.position = SPPos.transform.position;
            birdPos = Bird.Instance.bird().transform.position;

            //ゾンビの動きを止める
            Zombie.speed = 0;

            //飛んでいる岩を消す
            Destroy(GameObject.FindWithTag("Rock"));

            //強く引っ張れ！という画像を表示        
            hippareUI.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }

    private void SPmain()
    {
        if (Input.GetMouseButtonDown(0) && !pushes)
        {
            hippareUI.gameObject.SetActive(false);
            BirdJumper.Instance.MouseButtonDown();
            FingerPositions.Instance.getGameObj().GetComponent<SpriteRenderer>().sprite = FingerPositions.Instance.allowSprite[0];
            FingerPositions.Instance.getGameObj().transform.localRotation = Quaternion.Euler(0, 0, -90);
            //矢印の位置
            FingerPositions.Instance.getGameObj().transform.position = new Vector2(SPPos.transform.position.x, SPPos.transform.position.y + 1);
            pushes = true;
        }
        if (Input.GetMouseButton(0) && pushes)
        {
            //矢印の色を秒数によって変更する
            FingerPositions.Instance.AllowColorChange();

        }
        if (Input.GetMouseButtonUp(0) && pushes && FingerPositions.Instance.mouseDownTime > 4)
        {
            //Debug.Log("Release");            
            FingerPositions.Instance.getGameObj().SetActive(false);
            goUI.gameObject.SetActive(false);
            FingerPositions.Instance.mouseDownTime = 0;
            pushes = false;
            if (HissatsuFlag)
            {
                         //フィールド上のゾンビを一掃する
                //DestroyChildObject(zombieParent);

                Zombie.speed = 1;
                FingerPositions.Instance.getGameObj().GetComponent<SpriteRenderer>().sprite = FingerPositions.Instance.allowSprite[3];                
                AfterSPBool();
                Make.Instance.MakeZombie();
                //真下に鳥を飛ばす
                Bird.Instance.bird().GetComponent<Rigidbody2D>().AddForce(new Vector2(0, SPSpeed), ForceMode2D.Impulse);
                SpectrumEffect = true; // 追加者　イゴンヒ
                SpecuakSkill = true;// 追加者　イゴンヒ

                BirdJumper.Instance.GetComponent<BirdJumper>().enabled = false;

                StartCoroutine(SPBeforePos());
            }
        }
    }

    private void AfterSPBool()
    {
        Bird.Instance.Fly = true;
        Bird.Instance.Attack = true;
        Bird.Instance.CollisionBuilding = true;
        rePosBool = true;
        SPGimickStart = false;
    }

    private void BeforeSPBool()
    {
        SPGimickStart = true;
        rePosBool = false;
        Bird.Instance.Fly = false;
        Bird.Instance.Attack = false;
        Bird.Instance.CollisionBuilding = false;
        SPBool = false;
        doOnceSP = true;
    }
    private void DestroyChildObject(Transform parent_trans)
    {
        //必殺の技が発動し鳥がの速度が地面に当たったらゾンビが消える
        if (SpecuakSkill/* && Bird.Instance.rb2d.velocity == Vector2.zero*/) // 追加　イゴンヒ
        {
            for (int i = 0; i < parent_trans.childCount; ++i)
            {
                if (parent_trans.GetChild(i).GetComponent<Zombie>().inCamera == true)
                {
                    GameObject.Destroy(parent_trans.GetChild(i).gameObject);
                    Counter.Instance.Kill -= 1;
                    Make.Instance.ZombieQTY -= 1;
                }        
            }
        }
    }


    private IEnumerator SPBeforePos()
    {
        yield return new WaitForSeconds(1.5f);
        yield return null;
    }
}
