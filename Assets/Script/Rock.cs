using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private GameObject Bird;

    public Vector2 BirdTransform;
    [SerializeField]
    private float speed=1;
    private Rigidbody2D rb;
    private Vector2 Bird_RockTransform;
    [SerializeField]
    private float positionAdjustX,positionAdjustY;

    private void Awake()
    {
        Bird = GameObject.Find("Bird");
    }

    void Start()
    {
        //Bird = GameObject.Find("Bird");
        BirdTransform = Bird.transform.position;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        Bird_RockTransform.x = BirdTransform.x-this.transform.position.x + positionAdjustX;
        Bird_RockTransform.y = BirdTransform.y - this.transform.position.y + positionAdjustY;
        //Bird_RockTransform.x *= speed;
        Bird_RockTransform *= speed;
        rb.AddForce(Bird_RockTransform, ForceMode2D.Impulse);
    }

    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, BirdTransform, Time.deltaTime * 5);
        BirdTransform = Bird.transform.position;
        if (/*transform.position.x == BirdTransform.x||*/this.transform.position.x-BirdTransform.x<=-4)
        {
            Destroy(this.gameObject);
        }
       // Debug.Log(this.transform.position.x - BirdTransform.x);
    }
}
