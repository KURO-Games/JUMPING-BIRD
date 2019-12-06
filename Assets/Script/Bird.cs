using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    public float Life;//鳥のHP
    public GameObject Catapult;//最初の飛行判定
    public Sprite Bird1;//飛んでいる鳥のImage
    public Sprite Bird0;//飛んでいない鳥のImage
    public bool MouseInBird = false;
    public bool MousePush = false;//マウスが押しているか
    public bool Fly = false;//鳥が飛んでいるか
    public bool Attack = false;//攻撃状態
    public bool FirstJumpOver = false;
    Rigidbody2D rb2d;
    public float Jumphigh = 350f;
    public bool IsJump = true;
    public bool FirstJumpLimit = false;
    public bool Die = false;//死んだのか
    public bool CollisionBuilding = false;//ビルに当たったのか
    public GameObject Make;
    
    [SerializeField]
    private Image Gauge;

    [SerializeField]
    private Image birdIcon;
    private Color iconColor;

    public bool isEffect;

    private bool SPBool = false;
    private bool doOnceSP = true;
    [SerializeField]
    private GameObject SPPos;
    //[SerializeField]
    //private Image hippareUI;
    [SerializeField]
    private Text hippareText;
    [SerializeField]
    private GameObject Finger;




    void Start()
    {
        Gauge.fillAmount = 1;
        Life = 3f;
        rb2d = GetComponent<Rigidbody2D>();
        Make = GameObject.Find("Make");
        iconColor = birdIcon.color;
    }
    private void Update()
    {
        if(Gauge.fillAmount == 1 && doOnceSP)
        {
            doOnceSP = false;
            Debug.Log("GaugeMax");
            iconColor.a = 1;
            birdIcon.color = iconColor;
            SPBool = true;
        }
    }
    private void OnMouseEnter()
    {
        MouseInBird = true;
    }
    private void OnMouseExit()
    {
        MouseInBird = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Building")
        {
            if (Attack == false)
            {
                CollisionBuilding = true;
            }
            else
            {
                Destroy(other.gameObject);
                //360度をSPゲージのMAX値である20で割り、それを3ポイント分加算
                Gauge.fillAmount += (1f / 20f) * 3f;
                isEffect = true;
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            if (Attack == true)
            {
                Make.GetComponent<Make>().CanMakeBuilding = true;
                Destroy(other.gameObject);
                Gauge.fillAmount += (1f / 20f) * 3f;
            }
        }

        if (other.gameObject.tag == "Rock")
        {
            Debug.LogWarning("RockHit");
            if (Attack == false)
            {
                Life -= 1;
                Destroy(other.gameObject);
            }
            else
            {
                //Life -= 1;
                Destroy(other.gameObject);
            }
        }
    }

    void JumpReset()
    {
       IsJump = false;
    }

    void PositionYReset()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    void FixedUpdate()
    {

        if (Die == false)
        {
            if (Life <= 0)
            {
                transform.rotation = Quaternion.Euler(180, 0, 0);//gameover
                Die = true;
            }

            if (Fly == true)
            {
                Destroy(GetComponent<SpringJoint2D>());
                if (FirstJumpLimit == false)
                {
                    Invoke("JumpReset", 0.5f);
                    FirstJumpLimit = true;
                }
            }
            if (gameObject.transform.position.y < -3&& IsJump == false)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, -3);
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, Jumphigh));
                IsJump = true;
                Invoke("JumpReset", 0.5f);
                Attack = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                CollisionBuilding = false;
            }
            if (gameObject.transform.position.y > 7)
            {                
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, 6);
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                Invoke("PositionYReset", 0.5f);
                CollisionBuilding = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (CollisionBuilding == true)
            {                
                transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                Invoke("PositionYReset", 0.5f);
            }

            if(Attack == false && MousePush == false && FirstJumpOver == true && SPBool)
            {
                transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);
            }
        }
    }

    public void SPGimick()
    {
        if (SPBool)
        {
            IsJump = true;
            Fly = false;
            Attack = false;
            
            rb2d.velocity = Vector2.zero;
            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
            //ゲージを0にする
            Gauge.fillAmount = 0;            
            SPBool = false;
            //Debug.Log("inSP");

            //SPアイコンのa値を半分にする
            iconColor.a = 0.5f;            
            birdIcon.color = iconColor;            
            doOnceSP = true;

            //鳥が画面の真上に来る処理
            this.gameObject.transform.position = SPPos.transform.position;
            Destroy(GameObject.FindWithTag("Finger"));

            //ゾンビの動きを止める

            //飛んでいる岩を消す

            //SP技の関数を実行
            SPmain();
        }
        else
        {
            return;
        }
    }

    private IEnumerator WaitText(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void SPmain()
    {
        //強く引っ張れ！という画像を表示
        StartCoroutine(WaitText(1.5f));
        //hippareUI.gameObject.SetActive(true);
        hippareText.gameObject.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(Finger, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -5f), Quaternion.identity);
            GetComponent<SpringJoint2D>().connectedAnchor = SPPos.transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(SPPos.transform.position.x, SPPos.transform.position.y, -5f);
        }
            
    }
}
