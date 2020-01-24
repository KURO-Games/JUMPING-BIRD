using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : SingletonMonoBehaviour<Bird>
{
    public int Wave = 1;//今のステージレベル
    public int ZombieKill = 40;//必要なゾンビを倒す数

    [SerializeField]
    private int Wave1ZombieKill = 40;
    [SerializeField]
    private int Wave2ZombieKill = 60;
    [SerializeField]
    private int Wave3ZombieKill = 80;
    [SerializeField]
    private GameObject CounterText;

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

    public bool CrashBuilding;//イゴンヒ
    public bool CrashZombie;//イゴンヒ
    public bool DamageEffect; //イゴンヒ

    public Vector3 BuildingPos;
    public Vector3 ZombiePos;
    private Vector2 oldPosition;
    private BirdAnimationController _BirdAnimationController;    
        

    public bool isEffect;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie"&&Attack)
        {                     
            SoundManager.Instance.PlaySe(SE.AttackZombie);
            Make.GetComponent<Make>().CanMakeBuilding = true;
            Destroy(other.gameObject);
            Make.GetComponent<Make>().ZombieQTY -= 1;
            ZombiePos = other.transform.position;
            //360度をSPゲージのMAX値である20で割り、それを3ポイント分加算
            SPGimick.Instance.Gauge.fillAmount += (1f / 20f) * 2f;
            CrashZombie = true;
            CounterText.GetComponent<Counter>().Kill += 1;
        }

        if (other.gameObject.tag == "Rock")
        {
            Debug.LogWarning("RockHit");
            if (Attack == false)
            {
                Life -= 1;
                SoundManager.Instance.PlaySe(SE.Damage);
                Destroy(other.gameObject);

                DamageEffect = true; // イゴンヒ
            }
            else
            {
                //Life -= 1;
                Destroy(other.gameObject);
            }
        }

        //建物に当たったら
        if (other.gameObject.tag == "Building")
        {
            SoundManager.Instance.PlaySe(SE.AttackBuilding);
            BuildingPos = other.gameObject.transform.position;
            Debug.Log(BuildingPos);
            Destroy(other.gameObject);
            CrashBuilding = true;
            //360度をSPゲージのMAX値である20で割り、それを3ポイント分加算
            SPGimick.Instance.Gauge.fillAmount += (1f / 20f) * 3f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //地面に当たったら
        if (collision.gameObject.tag == "Ground")
        {
            rb2d.velocity = Vector2.zero;
            Attack = false;
            CollisionBuilding = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
        if (Wave == 1)
        {
            ZombieKill = Wave1ZombieKill;
        }
        else if(Wave == 2)
        {
            ZombieKill = Wave2ZombieKill;
        }
        else if (Wave == 3)
        {
            ZombieKill = Wave3ZombieKill;
        }
        
        if (Die == false)　//もし死んでいなかったら
        {
            if (Life <= 0)　//ライフが0になったら
            {                
                SoundManager.PlayBgm(BGM.GameOver);
                transform.rotation = Quaternion.Euler(180, 0, 0);//gameover鳥のY軸を180度反転
                Die = true;
                StartCoroutine(SceneFades(3f));
                DisplayManager.Instance.DispMgr(false);
            }
            
            if (AngleCal(oldPosition, transform.position) < 0&&Attack)
            {
                BirdAnimationController.BirdAnimations(BirdAnimationController.BirdAnimParam.Ricochet);
            }

            oldPosition = transform.position;
        } 
    }
    private float AngleCal(Vector2 startpos, Vector2 targetpos)
    {
        Vector2 dt = targetpos - startpos;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }
}
