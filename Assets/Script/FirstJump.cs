using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstJump : MonoBehaviour
{/*
    private Bird _birdScript;
    [SerializeField]
    private GameObject Make;
    void Awake()
    {
        _birdScript = this.gameObject.GetComponent<Bird>();
    }

    void Update()
    {
        if (_birdScript.MouseInBird == true && Input.GetMouseButtonDown(0))
        {
            _birdScript.MousePush = true;
        }

        if (_birdScript.MousePush == true)
        {           
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            transform.position = mousePos;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;            
        }
        if (_birdScript.MousePush == true && Input.GetMouseButtonUp(0))
        {            
            _birdScript.MousePush = false;
            _birdScript.Fly = true;
            _birdScript.Attack = true;
            _birdScript.FirstJumpOver = true;
            Destroy(this);
        }

    }
    */
}
