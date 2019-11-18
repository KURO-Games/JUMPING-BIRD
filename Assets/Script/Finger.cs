using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{
    public GameObject Bird;
    public bool Over = false;
    public bool Limit = true;
    Vector3 rotat;

    void Start()
    {
        Bird = GameObject.Find("Bird");
    }

    void JumpLimitSet()
    {
        Limit = false;
    }

    void PositionYReset()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    void PositionFix()
    {
        gameObject.transform.position = Bird.transform.position;
    }

    private void Update()
    {
        rotat.z = Angle(this.transform.position,Bird.transform.position);
        this.transform.rotation=Quaternion.Euler(rotat);
    }
    void FixedUpdate()
    {
        if (!Over)
        {
            
            GetComponent<SpringJoint2D>().connectedAnchor = Bird.transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            
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
            Bird.GetComponent<Bird>().MousePush = false;
            Bird.GetComponent<Bird>().Fly = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Bird.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Bird.GetComponent<Bird>().Attack = true;
            Over = true;
            Destroy(GetComponent<SpriteRenderer>());
            Invoke("PositionFix", 0.1f);
            Invoke("JumpLimitSet", 0.5f);
        }
        if (gameObject.transform.position.y > 7)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 6);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            Invoke("PositionYReset", 0.5f);
        }
    }
    private float Angle(Vector2 startpos,Vector2 targetpos)
    {
        Vector2 dt = targetpos - startpos;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }
}

