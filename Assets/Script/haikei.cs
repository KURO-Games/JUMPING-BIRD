using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haikei : MonoBehaviour
{
    [SerializeField]
    private GameObject bird;
    private float size = 20;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(gameObject.transform.position.x < bird.transform.position.x - size)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + size*2, gameObject.transform.position.y, 9);
        }
        else if (gameObject.transform.position.x > bird.transform.position.x + size)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - size * 2, gameObject.transform.position.y, 9);
        }
    }
}
