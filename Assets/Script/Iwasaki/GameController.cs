using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum birdState
    {
        Start,
        Bound,
        Attack,
        PullReady
    }
    public static birdState nowState;
    [SerializeField]
    private GameObject bird;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        nowState = birdState.Start;
        rb = bird.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (nowState)
        {
            case birdState.Start:

                break;

            case birdState.PullReady:
                //X,Yを固定する       
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
                break;

            case birdState.Attack:
                //Attack中は無敵  
                rb.constraints = RigidbodyConstraints2D.None;
                break;

            case birdState.Bound:
                //上下にバウンドさせる
                break;
        }
    }
}
