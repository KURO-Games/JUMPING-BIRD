using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Vector2 BirdTransform;
    [SerializeField]
    private float speed=1;
    private Rigidbody2D rb;
    private Vector2 Bird_RockTransform;
    [SerializeField]
    private float positionAdjustX,positionAdjustY;

    private void Awake()
    {

    }

    void Start()
    {
        //Bird = GameObject.Find("Bird");
        BirdTransform = Bird.Instance.bird().transform.position;
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
        BirdTransform = Bird.Instance.bird().transform.position;
        if (this.transform.position.x-BirdTransform.x<=-4 || SPGimick.Instance.SPGimickStart)
        {
            Destroy(this.gameObject);
        }
       // Debug.Log(this.transform.position.x - BirdTransform.x);
    }
}
