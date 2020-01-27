using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRoop : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;
    private float cloudSize = 20.5f;
    [SerializeField]
    private float cloudSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((-0.1f * cloudSpeed), 0, 0);
        if (transform.position.x < mainCamera.transform.position.x - cloudSize)
        {
            transform.position = new Vector3(mainCamera.transform.position.x + cloudSize, -0.36f, 10);
        }
    }
}
