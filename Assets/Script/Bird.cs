using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool Die = false;
    void Start()
    {
        Life = 3f;
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnMouseEnter()
    {
        MouseInBird = true;
    }
    private void OnMouseExit()
    {
        MouseInBird = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Building" && Attack == true)
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Zombie")
        {
            if (Attack == false)
            {
                Life -= 1;
            }
            else
            {
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

    void Update()
    {

        if (Die == false)
        {
            if (Life <= 0)
            {
                GetComponent<SpriteRenderer>().sprite = Bird0;//gameover\
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
            if (gameObject.transform.position.y < -3 && Fly == true && IsJump == false)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, -3);
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, Jumphigh));
                IsJump = true;
                Invoke("JumpReset", 0.5f);
                Attack = false;
            }
            if (gameObject.transform.position.y > 7)
            {
                gameObject.transform.position = new Vector2(gameObject.transform.position.x, 6);
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
                Invoke("PositionYReset", 0.5f);

            }
        }
    }
}
