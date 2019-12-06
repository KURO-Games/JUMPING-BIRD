using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    [SerializeField]
    private GameObject bird;
    private float size = 20.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mainCamera.transform.position = new Vector3(bird.transform.position.x + 3.6f, bird.transform.position.y + 2.7f, bird.transform.position.z + zAdjust);
        if (gameObject.transform.position.x < bird.transform.position.x - size)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + size * 2, gameObject.transform.position.y);
        }
        else if (gameObject.transform.position.x > bird.transform.position.x + size)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - size * 2, gameObject.transform.position.y);
        }
    }
}
