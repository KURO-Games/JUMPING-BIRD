using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRoop : MonoBehaviour
{
    private int num = 1;
    [SerializeField]
    private GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.05f, 0, 0);
        if (transform.position.x < mainCamera.transform.position.x - 20.3f)
        {
            transform.position = new Vector3(mainCamera.transform.position.x + 20.3f, 1, 10);
        }
    }
}
