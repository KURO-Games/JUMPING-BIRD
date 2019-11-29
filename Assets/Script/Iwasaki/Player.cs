using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;
    Vector2 startPos;
    private float speed = 100;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {        
        rb = bird.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //もし鳥のstateがstartだったら。
        if(GameController.nowState == GameController.birdState.Start)
        {
            bird.transform.position = new Vector2(-3.6f, -2.7f);            
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouseDown");
            GameController.nowState = GameController.birdState.PullReady;
            this.startPos = Input.mousePosition;            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("mouseUp");
            GameController.nowState = GameController.birdState.Attack;
            Vector2 endPos = Input.mousePosition;
            Vector2 startDirection = -1 * (endPos - startPos).normalized;
            this.rb.AddForce(startDirection * speed);
        }
    }
}
