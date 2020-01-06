using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haikei : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;
    [SerializeField]
    private int Size = 20;
    [SerializeField]
    private float _Size = 25;
    void Update()
    {
        ////カメラサイズ5の場合
        //if (gameObject.transform.position.x < bird.transform.position.x - Size)
        //{
        //    gameObject.transform.position = new Vector3(gameObject.transform.position.x + Size * 2, gameObject.transform.position.y, 9);
        //}
        //else if (gameObject.transform.position.x > bird.transform.position.x + Size)
        //{
        //    gameObject.transform.position = new Vector3(gameObject.transform.position.x - Size * 2, gameObject.transform.position.y, 9);
        //}

        //カメラサイズ7の場合
        if (gameObject.transform.position.x < bird.transform.position.x - Size)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + Size * 3, gameObject.transform.position.y, 9);
        }
        else if (gameObject.transform.position.x > bird.transform.position.x + _Size)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - Size * 3, gameObject.transform.position.y, 9);
        }
    }
}
