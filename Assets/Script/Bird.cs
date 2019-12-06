﻿using System.Collections;
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
    public bool Die = false;//死んだのか
    public bool CollisionBuilding = false;//ビルに当たったのか
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

            if(Attack == false && MousePush == false && FirstJumpOver == true)
            {
                transform.position = new Vector2(transform.position.x + 0.02f, transform.position.y);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
