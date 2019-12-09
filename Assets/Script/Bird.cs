using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird :SingletonMonoBehaviour<Bird>
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
    public bool IsJump = true; //連続のジャンプを防ぐためのもの
    public bool FirstJumpLimit = false;
    public bool Die = false;//死んだのか
    public bool CollisionBuilding = false;//ビルに当たったのか、trueにすると跳ね返る
    public GameObject Make;

    public bool CrashBuilding = false;
    public bool CrashZombie = false;
    public Vector3 BuildingPos;

   public  Collider[] hitColliders;

    void Start()
    {
        Life = 3f;
        rb2d = GetComponent<Rigidbody2D>();
        Make = GameObject.Find("Make");
    }
    private void OnMouseEnter()
    {
        MouseInBird = true;
    }
    private void OnMouseExit()
    {
        MouseInBird = false;
    }

    public GameObject bird()
    {
        
        return this.gameObject;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Building")
        {
            if (Attack == false)　//引っ張てない状態(自動ジャンプ)てビルに当たると攻撃状態はfalse
            {
                CollisionBuilding = true;　
            }
            else
            {
                BuildingPos = other.gameObject.transform.position;
                Debug.Log(BuildingPos);
                Destroy(other.gameObject);
                CrashBuilding = true;
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
                CrashZombie = true;
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

        if (Die == false)　//もし死んでいなかったら
        {
            if (Life <= 0)　//ライフが0になったら
            {
                transform.rotation = Quaternion.Euler(180, 0, 0);//gameover鳥のY軸を180度反転
                Die = true;
            }

            if (Fly == true)　//ここは一回目の飛ぶ処理　一回目のジャンプが終わったらFly = true
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
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, -3);//Y座標が-3より低かったら一旦-3に戻る
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, Jumphigh));//自動ジャンプを行う
                IsJump = true;
                Invoke("JumpReset", 0.5f);//自動のジャンプは1回行ったら0.5秒内自動ジャンプはしない
                Attack = false;　//地面(YY座標<-3)になったら攻撃状態をfalseにする
                transform.rotation = Quaternion.Euler(0, 0, 0);//鳥のローテーションをリセット
                CollisionBuilding = false;//跳ね返る状態終了
            }
            if (gameObject.transform.position.y > 7)//ここが高く飛び過ぎないようにの制限  
            {                
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, 6);//Y座標が7より高かったら一旦6に戻る
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;//それ以上高く飛ぶことを中止するために一旦Y座標を固定
                Invoke("PositionYReset", 0.5f);//0.5秒後固定を解除
                CollisionBuilding = false;//跳ね返る状態終了　ここにもう一回書くのはバグ防止のため　
                transform.rotation = Quaternion.Euler(0, 0, 0);//鳥のローテーションをリセット　同じバグ防止のため
            }
            if (CollisionBuilding == true)//引っ張ってない状態ビルに当たって、跳ね返る処理
            {                
                transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);//左側に移動
                transform.rotation = Quaternion.Euler(0, 180, 0);　//X軸を反転
                Invoke("PositionYReset", 0.5f);//固定を解除
            }

            if(Attack == false && MousePush == false && FirstJumpOver == true)
            {
                transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);//自動で前に進めるの処理
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
