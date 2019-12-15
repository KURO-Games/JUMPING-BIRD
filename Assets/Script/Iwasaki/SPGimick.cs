using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPGimick : SingletonMonoBehaviour<SPGimick>
{ 
    private bool HissatsuWazaBool = false;    
    
    public Image Gauge;

    [SerializeField]
    private Image birdIcon;
    private Color iconColor;    

    public bool SPBool = false;
    private bool doOnceSP = true;    
    public GameObject SPPos;
    //[SerializeField]
    //private Image hippareUI;
    [SerializeField]
    private Text hippareText;
    [SerializeField]
    private float SPSpeed;
    private bool buttonPushFlag;
    public bool SPGimickStart;
    private Vector2 birdPos;
    // Start is called before the first frame update
    void Start()
    {
        iconColor = birdIcon.color;
        Gauge.fillAmount = 1;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gauge.fillAmount == 1 && doOnceSP)
        {
            doOnceSP = false;
            Debug.Log("GaugeMax");
            iconColor.a = 1;
            birdIcon.color = iconColor;
            SPBool = true;
        }

        if (SPGimickStart)
        {
            Bird.Instance.bird().transform.position = birdPos;
            //SP技の関数を実行
            SPmain();
        }
    }
    public void HissatsuWaza()
    {
        Debug.Log("click");
        if (SPBool)
        {
            BeforeSPBool();

            //必殺技ゲージを0にする
            Gauge.fillAmount = 0;

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
            hippareText.gameObject.SetActive(true);
            //hippareUI.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }    

    private void SPmain()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            hippareText.gameObject.SetActive(false);
            BirdJumper.Instance.MouseButtonDown(false, true, 1.7f, 1.7f, 0);
            FingerPositions.Instance.getGameObj().GetComponent<SpriteRenderer>().sprite = FingerPositions.Instance.allowSprite[0];
            FingerPositions.Instance.getGameObj().transform.localRotation = Quaternion.Euler(0, 0, -90);
            //Debug.Log(finger.transform.rotation);
            FingerPositions.Instance.getGameObj().transform.position = new Vector2(SPPos.transform.position.x, SPPos.transform.position.y + 1);
        }
        if (Input.GetMouseButton(0))
        {
            FingerPositions.Instance.AllowColorChange();
        }
        if (Input.GetMouseButtonUp(0))
        {
            FingerPositions.Instance.getGameObj().SetActive(false);
            if (!buttonPushFlag)
            {
                FingerPositions.Instance.mouseDownTime = 0;
                if (FingerPositions.Instance.HissatsuFlag)
                {
                    Bird.Instance.bird().GetComponent<Rigidbody2D>().AddForce(new Vector2(0, SPSpeed), ForceMode2D.Impulse);
                    AfterSPBool();
                    Zombie.speed = 1;
                    FingerPositions.Instance.getGameObj().GetComponent<SpriteRenderer>().sprite = FingerPositions.Instance.allowSprite[3];
                }
                else
                {
                    
                }
            }
            buttonPushFlag = false;
        }
    }

    private void AfterSPBool()
    {
        SPGimickStart = false;
        buttonPushFlag = false;
        HissatsuWazaBool = false;
        //Bird.Instance.IsJump = false;
        Bird.Instance.Fly = true;
        Bird.Instance.Attack = true;
        Bird.Instance.CollisionBuilding = true;
        SPGimickStart = false;        
    }

    private void BeforeSPBool()
    {
        SPGimickStart = true;
        buttonPushFlag = true;
        HissatsuWazaBool = true;
        //Bird.Instance.IsJump = true;
        Bird.Instance.Fly = false;
        Bird.Instance.Attack = false;
        Bird.Instance.CollisionBuilding = false;
        SPBool = false;
        doOnceSP = true;
    }
}
