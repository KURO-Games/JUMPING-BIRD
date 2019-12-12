using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : SingletonMonoBehaviour<CameraFollow>
{
    [SerializeField]
    //private GameObject Bird;


    Vector3 offset;
    void Start()
    {
        //Bird = GameObject.FindGameObjectWithTag("Bird");

    }
    void Update()
    {
        if (Bird.Instance.Fly == true)
        {
            if (Bird.Instance.bird().transform.position.y >= 2)
            {
                transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 3f, Bird.Instance.bird().transform.position.y - 2, -10);
            }
            else transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 3f, 0, -10);
        }
    }
    public Vector3 CameraThisPosition()
    {
        return this.gameObject.transform.position;
    }
    public void CameraPos(Vector3 position)
    {
        this.gameObject.transform.position = position;
    }
}