using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : SingletonMonoBehaviour<Bird>
{    

    public int Life;//鳥のHP
    //public bool MouseInBird = false;
    //public bool MousePush = false;//マウスが押しているか
    public bool Fly = false;//鳥が飛んでいるか
    public bool Attack = false;//攻撃状態
    //public bool FirstJumpOver = false;
    [HideInInspector]
     public Rigidbody2D rb2d; //Publicで変更
    public float Jumphigh = 350f;
    //public bool IsJump; //連続のジャンプを防ぐためのもの
    //public bool FirstJumpLimit;
    public bool Die;//死んだのか
    public bool CollisionBuilding;//ビルに当たったのか、trueにすると跳ね返る
    public GameObject Make;

    [HideInInspector]
    public bool CrashBuilding;//イゴンヒ
    [HideInInspector]
    public bool CrashZombie;//イゴンヒ
    [HideInInspector]
    public bool isDamaged; //イゴンヒ

    [HideInInspector]
    public Vector3 BuildingPos;
    [HideInInspector]
    public Vector3 ZombiePos;
    private Vector2 oldPosition;
    private BirdAnimationController _BirdAnimationController;
    [SerializeField]
    private GameObject DeathPos;
    [HideInInspector]
    public bool cantSPBool;
    private bool doOnceAttack = true;

    public bool isEffect;
    [SerializeField]
    private GameObject birdShadow;
    [SerializeField]
    private float shadowScale = 1.5f;

    [HideInInspector]
    public bool isGround; //イゴンヒ
    [HideInInspector]
    public bool isClear; //イゴンヒ

    private bool shadowBool = true;
    enum BirdState
    {
        wait,
        Jump,
        Attack,
        fall,
        Die,
    }
    BirdState _birdState;
    //public Collider[] hitColliders;

    void Start()
    {
        Debug.Log("kill" + Counter.Instance.Kill);
        _birdState = BirdState.wait;
        _BirdAnimationController = BirdAnimationController.Instance;
        Life = 3;
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        Fly= true;
        Attack = true;
        CollisionBuilding = true;
    }
   
    public GameObject bird()
    {
        return this.gameObject;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            if (doOnceAttack && Attack)
            {
                //Debug.Log(other.gameObject.GetComponent<ZombieState>().HitPoint);
                doOnceAttack = false;
                other.gameObject.GetComponent<ZombieState>().HitPoint -= 1;
                SoundManager.Instance.PlaySe(SE.AttackZombie);
                if (other.gameObject.GetComponent<ZombieState>().HitPoint <= 0)
                {
                    Debug.Log(Counter.Instance.Kill);
                    Counter.Instance.Kill -= 1;
                    BirdAnimationController.BirdAnimations(BirdAnimationController.BirdAnimParam.ZonbieHit);
                    Make.GetComponent<Make>().CanMakeBuilding = true;
                    Make.GetComponent<Make>().ZombieQTY -= 1;
                    ZombiePos = other.transform.position;
                    //360度をSPゲージのMAX値である20で割り、それを3ポイント分加算
                    SPGimick.Instance.Gauge.fillAmount += (1f / 20f) * 2f;
                    other.gameObject.GetComponent<Animator>().SetTrigger("");
                    Destroy(other.gameObject);
                    CrashZombie = true;
                                        
                }                
            }            
        }

        //必殺技を打てない場所を作成
        if (other.gameObject.tag == "CantSP")
        {
            cantSPBool = true;
            if(SPGimick.Instance.Gauge.fillAmount == 1)
            {
                SPGimick.Instance.iconCanGroup.alpha = 0.6f;
            }

            //Debug.Log("inCantsp");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Rock")
        {
            //Debug.LogWarning("RockHit");
            if (Attack == false)
            {
                Life -= 1;
                SoundManager.Instance.PlaySe(SE.Damage);
                Destroy(other.gameObject);
                BirdAnimationController.BirdAnimations(BirdAnimationController.BirdAnimParam.HitStone);
                isDamaged = true; // イゴンヒ
            }
            else
            {
                //Life -= 1;
                Destroy(other.gameObject);
            }
        }              

        //穴に落ちたら
        if(other.tag == "Death")
        {
            //this.gameObject.SetActive(false);
            transform.position = new Vector3(DeathPos.transform.position.x, DeathPos.transform.position.y);
            Life -= 1;
            StartCoroutine(DeathTimer(1.5f));
        }

        if (other.tag == "Goal")
        {
            DisplayManager.Instance.DispMgr(true);
            StartCoroutine(SceneFades(5f));
            GetComponent<BirdJumper>().enabled = false;    /*イゴンヒ*/
            isClear = true;

        }
        if (other.gameObject.tag == "NoShadow")
        {
            shadowBool = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面に当たったら
        if (collision.gameObject.tag == "Ground")
        {
        SoundManager.Instance.PlaySe(SE.AttackZombie);
            this.transform.rotation = Quaternion.Euler(0,0,0);
            rb2d.velocity = Vector2.zero;
            Attack = false;
            CollisionBuilding = false;
            BirdAnimationController.BirdAnimations(BirdAnimationController.BirdAnimParam.Normal);
            isGround = true;

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground") isGround = false;

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CantSP")
        {
            cantSPBool = false;
            SPGimick.Instance.iconCanGroup.alpha = 1.0f;
       
        }

        if(collision.gameObject.tag == "Zombie")
        {
            doOnceAttack = true;
        }

        if (collision.gameObject.tag == "NoShadow")
        {
            shadowBool = true;
        }
    }
    IEnumerator PositionYReset()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
    IEnumerator SceneFades(float fadeTime)
    {
        yield return new WaitForSeconds(fadeTime);
        SceneLoadManager.LoadScene("Title");
    }

    void Update()
    {        
        if (Die == false)　//もし死んでいなかったら
        {
            if (Life <= 0)　//ライフが0になったら
            {                
                SoundManager.PlayBgm(BGM.GameOver);
                transform.rotation = Quaternion.Euler(180, 0, 0);//gameover鳥のY軸を180度反転
                Die = true;
                StartCoroutine(SceneFades(3f));
                DisplayManager.Instance.DispMgr(false);
                GetComponent<BirdJumper>().enabled = false;

            }
            
            if (AngleCal(oldPosition, transform.position) < 0&&Attack)
            {
//                BirdAnimationController.BirdAnimations(BirdAnimationController.BirdAnimParam.Ricochet);
            }

            oldPosition = transform.position;
        } 
        ShadowCalculation();

    }
    private float AngleCal(Vector2 startpos, Vector2 targetpos)
    {
        Vector2 dt = targetpos - startpos;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }

    private IEnumerator DeathTimer(float waitTime)
    {
        this.rb2d.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionY  | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(waitTime);
        this.rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }    
    private void ShadowCalculation()
    {
        if (this.transform.position.y <= 0 && shadowBool)
        {
            birdShadow.gameObject.SetActive(true);
            birdShadow.transform.position = new Vector3(this.transform.position.x, -5.7f, 0);
            birdShadow.transform.localScale = new Vector3(this.transform.position.y * shadowScale, this.transform.position.y * shadowScale, 0);
        }
        else
        {
            birdShadow.gameObject.SetActive(false);
        }
    }
}
