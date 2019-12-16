using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : SingletonMonoBehaviour<CameraFollow>
{
    [SerializeField]
    //private GameObject Bird;
    private float _set=5f;
    [SerializeField]
    bool NearGoal;
    [SerializeField]
    float offset;
    Vector3 after;
    void Start()
    {
        //Bird = GameObject.FindGameObjectWithTag("Bird");
        after.z = this.transform.position.z;
    }
    void Update()
    {
        offset = GoleFlags.Instance.ThisPosition().x - this.gameObject.transform.position.x;
        
        if (offset <= _set)
        {
            Instance.NearGoal = true;

        }
        if (!NearGoal)
        {
            if (Bird.Instance.Fly)
            {
                //if (Bird.Instance.bird().transform.position.y >= 2)
                //{
                //    transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 3f, Bird.Instance.bird().transform.position.y - 2, -10);
                //}
                //else transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 3f, 0, -10);
                if(Bird.Instance.bird().transform.position.y >= 5.7f)
                transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 3f, 0, -10);
            }
            after.y = this.transform.position.y;
        }
        else
        {
            after.x = this.transform.position.x;
            this.transform.position = after;
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
    public GameObject gameObjects()
    {
        return this.gameObject;
    }
}