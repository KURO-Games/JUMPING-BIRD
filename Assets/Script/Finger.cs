using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Body;
    public bool Over = false;
    void Start()
    {
        Bird = GameObject.Find("Bird");
        Body = GameObject.Find("Body");
    }
    void PositionYReset()
    {
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
    void Update()
    {

        if (Over == false)
        {
            GetComponent<SpringJoint2D>().connectedAnchor = Body.transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            transform.position = mousePos;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
            if (Input.GetMouseButtonUp(0)&&gameObject.transform.position.x < Bird.transform.position.x)
        {
            Bird.GetComponent<Bird>().MousePush = false;
            Bird.GetComponent<Bird>().Fly = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Bird.GetComponent<Bird>().Attack = true;
            Over = true;
            Destroy(GetComponent<SpriteRenderer>()); 
        }
        

        if (gameObject.transform.position.y < -3&&Over == true)
        {
            Destroy(gameObject);
        }
        if (gameObject.transform.position.y > 7)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, 6);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            Invoke("PositionYReset", 0.5f);

        }

        if(gameObject.transform.position.x > Bird.transform.position.x&&Over == true)
        {
            Bird.transform.position = gameObject.transform.position;
            Destroy(GetComponent<SpringJoint2D>());
        }
    }
}
