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
    Rigidbody2D rb2d;
    public float Jumphigh = 350f;
    //public bool IsJump; //連続のジャンプを防ぐためのもの
    //public bool FirstJumpLimit;
    public bool Die;//死んだのか
    public bool CollisionBuilding;//ビルに当たったのか、trueにすると跳ね返る
    public GameObject Make;
    public bool CrashBuilding;
    public bool CrashZombie;
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

    void OnTriggerStay2D(Collider2D other)
    {
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
        if (other.gameObject.name == "Goal")
        {
            SoundManager.PlayBgm(BGM.Clear);
            DisplayManager.Instance.DispMgr(true);
            
            StartCoroutine(SceneFades(5f));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie"&&Attack)
        {
                SoundManager.Instance.PlaySe(SE.AttackZombie);
                Make.GetComponent<Make>().CanMakeBuilding = true;
                Destroy(other.gameObject);
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
            }
            else
            {
                //Life -= 1;
                Destroy(other.gameObject);
            }
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
        if(Wave == 1)
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
            
            if (gameObject.transform.position.y <= -5.5f)//地面停止スクリプト。残しておく。
            {
                //BirdAnimationController.BirdAnimations(BirdAnimationController.BirdAnimParam.Normal);
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, -5.5f);//Y座標が-3より低かったら一旦-3に戻る
                rb2d.velocity = Vector2.zero;
                Attack = false;　//地面(YY座標<-3)になったら攻撃状態をfalseにする
                CollisionBuilding = false;//跳ね返る状態終了
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (gameObject.transform.position.y >= 6)//ここが高く飛び過ぎないようにの制限 //高さ制限がなくなったが、αまでに変更が難しいため残しておく。 
            {                
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, 5f);//Y座標が7より高かったら一旦6に戻る
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;//それ以上高く飛ぶことを中止するために一旦Y座標を固定
                StartCoroutine(PositionYReset());//0.5秒後固定を解除
                CollisionBuilding = false;//跳ね返る状態終了　ここにもう一回書くのはバグ防止のため　
            }
            if (CollisionBuilding == true)//引っ張ってない状態ビルに当たって、跳ね返る処理//自動で進まなくなったので、ビルに当たらなくなったが、デバッグ中のため現状残しておく。
            {                
                transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);//左側に移動
                transform.rotation = Quaternion.Euler(0, 180, 0);　//X軸を反転
                StartCoroutine(PositionYReset());//固定を解除
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
