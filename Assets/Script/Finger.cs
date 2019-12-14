using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finger : SingletonMonoBehaviour<Finger>
{
    [SerializeField]
    private GameObject Bird;
    private Bird _Bird;
    private bool Over = false;
    private bool Limit = true;
    private readonly float yLimit = 5;
    Vector3 rotat;
    private bool limitPos = true;
    private float fingerPos = 0;
    
    void Start()
    {
        Bird = GameObject.FindGameObjectWithTag("Bird");
    }

    IEnumerator JumpLimitSet()
    {
        yield return new WaitForSeconds(0.5f);
        Limit = false;
    }

    IEnumerator PositionYReset()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("aaaaa");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    IEnumerator PositionFix()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.position = Bird.transform.position;
    }

    private void Update()
    {
        if (SPGimick.Instance.SPGimickStart) return;
        rotat.z = AngleCal(this.transform.position,Bird.transform.position);
        this.transform.rotation=Quaternion.Euler(rotat);
        if (!Over)
        {            
            Vector3 birdPos = Bird.transform.position;
            //Debug.Log("MouseDown");
            //GetComponent<SpringJoint2D>().connectedAnchor = Bird.transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
            //GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

        }
        else
        {
            if (gameObject.transform.position.y < -3 && Limit == false)
            {
                Destroy(gameObject);
            }

            if (gameObject.transform.position.x > Bird.transform.position.x)
            {
                Bird.transform.position = transform.position;
                Destroy(GetComponent<SpringJoint2D>());
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            /*
            //Debug.Log("MouseUp");
            setBool();
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Bird.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            */
            Destroy(GetComponent<SpriteRenderer>());
            StartCoroutine(PositionFix());
            StartCoroutine(JumpLimitSet());
        }

        //画面外にマウスを飛ばしてもゲーム画面内に矢印が残る処理。
        FingerLimit();
    }   
    private float AngleCal(Vector2 startpos,Vector2 targetpos)
    {
        Vector2 dt = targetpos - startpos;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }

    private void setBool()
    {
        Bird.GetComponent<Bird>().Attack = true;
        Bird.GetComponent<Bird>().MousePush = false;
        Bird.GetComponent<Bird>().Fly = true;
        Over = true;
    }

    private void FingerLimit()
    {
        if (Math.Abs(gameObject.transform.position.y) > yLimit)
        {
            if (limitPos)
            {
                limitPos = false;
                fingerPos = Mathf.Round(gameObject.transform.position.y);
                //Debug.Log(fingerPos);
            }
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, fingerPos);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            StartCoroutine(PositionYReset());
        }
        else if (Math.Abs(gameObject.transform.position.y) < yLimit)
        {
            limitPos = true;
        }
    }
}

