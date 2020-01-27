using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : SingletonMonoBehaviour<CameraFollow>
{
    private float _set=5f;
    [SerializeField]
    bool NearGoal;
    [SerializeField]
    float offset;
    Vector3 after;
    private bool backDoOnce = true;
    [SerializeField]
    private GameObject rightEnd;
    [HideInInspector]
    public bool AllowBool;
    [SerializeField]
    private Image goalAllow;
    [SerializeField]
    public BoxCollider2D goalCol;

    void Start()
    {
        //Bird = GameObject.FindGameObjectWithTag("Bird");
        after.z = this.transform.position.z;
        //新しく広くしたカメラの大きさ
        this.gameObject.GetComponent<Camera>().orthographicSize = 7;
        //今までのカメラの大きさ        
        //this.gameObject.GetComponent<Camera>().orthographicSize = 5;        
    }
    void Update()
    {
        offset = rightEnd.transform.position.x - this.gameObject.transform.position.x + 5.5f;        
        if (offset <= _set)
        {
            NearGoal = true;
        }
        else NearGoal = false;
        if (!NearGoal)
        {
            if (Bird.Instance.Fly && !SPGimick.Instance.SPGimickStart)
            {
                //if (Bird.Instance.bird().transform.position.y >= 2)
                //{
                //    transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 3f, Bird.Instance.bird().transform.position.y - 2, -10);
                //}
                //else transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 3f, 0, -10);
                transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 5,0, -10);                

                //マリオっぽく画面外に言ったら矢印を出すようにした
                //if(Bird.Instance.bird().transform.position.y >= 5.7f)
                //{
                //    birdHereUI.gameObject.SetActive(true);
                //    birdHereUI.transform.position = new Vector2(Bird.Instance.bird().transform.position.x, 4.3f);
                //    transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 3f, 0, -10);
                //}
                //else
                //{
                //    birdHereUI.gameObject.SetActive(false);
                //    transform.position = new Vector3(Bird.Instance.bird().transform.position.x + 3f, 0, -10);
                //}
            }
            after.y = this.transform.position.y;
        }
        else
        {
            //if (Bird.Instance.bird().transform.position.x <= this.transform.position.x )
            //{
            //    Debug.Log("aaa");
            //    NearGoal = false;
            //    doOnce = true;
            //}
            if (backDoOnce && AllowBool)
            {
                goalCol.isTrigger = false;
                goalAllow.gameObject.SetActive(false);
                backDoOnce = false;
                SoundManager.PlayBgm(BGM.ClearField);
            }
            //after.x = this.transform.position.x;
            //this.transform.position = after;
        }
        if (AllowBool)
        {
            goalAllow.gameObject.SetActive(true);
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