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
    private GameObject finger;
    // Start is called before the first frame update
    void Start()
    {
        iconColor = birdIcon.color;
        Gauge.fillAmount = 1;
        finger = FingerPositions.Instance.getGameObj();
        Debug.Log(finger.transform.rotation);
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
            SPGimickStart = true;
            buttonPushFlag = true;
            HissatsuWazaBool = true;
            Bird.Instance.IsJump = true;
            Bird.Instance.Fly = false;
            Bird.Instance.Attack = false;
            Bird.Instance.CollisionBuilding = false;

            //Bird.Instance.bird().GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //rb2d.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            //ゲージを0にする
            Gauge.fillAmount = 0;
            SPBool = false;
            //Debug.Log("inSP");

            //SPアイコンのa値を半分にする
            iconColor.a = 0.5f;
            birdIcon.color = iconColor;
            doOnceSP = true;

            //鳥が画面の真上に来る処理
            Bird.Instance.bird().transform.position = SPPos.transform.position;
            birdPos = Bird.Instance.bird().transform.position;

            //ゾンビの動きを止める
            Zombie.speed = 0;
            Zombie.ZAttack = true;

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
            BirdJumper.Instance.MouseButtonDown(false,false,0,0,1);
            finger.GetComponent<SpriteRenderer>().sprite = FingerPositions.Instance.allowSprite[0];
            finger.transform.rotation = new Quaternion(0, 0, 90, 0);
            Debug.Log(finger.transform.rotation);
            finger.transform.position = SPPos.transform.position;
        }
        if (Input.GetMouseButton(0))
        {
            FingerPositions.Instance.AllowColorChange();
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!buttonPushFlag)
            {
                if (FingerPositions.Instance.HissatsuFlag)
                {
                    Bird.Instance.bird().GetComponent<Rigidbody2D>().AddForce(new Vector2(0, SPSpeed), ForceMode2D.Impulse);
                    SPGimickStart = false;
                }
            }
            buttonPushFlag = false;
        }
    }
}
