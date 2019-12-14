using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJumper : SingletonMonoBehaviour<BirdJumper>
{
    private Vector2 thisPosition;
    private Vector2 AddForcePos;
    private Vector3 cameraPos;
    private Vector2 distance;
    private float rayDistance = 1000f;
    private bool RayFlag;

[SerializeField]
    private float Speed=2;
    [SerializeField]
    private GameObject _Finger;
    private void Update()
    {
        if (this.GetComponent<Bird>().FirstJumpLimit)
        {
            Debug.LogWarning(Bird.Instance.FirstJumpLimit);
            if (Input.GetMouseButtonDown(0)&&!RayFlag)
            {
                Ray ray = CameraFollow.Instance.gameObjects().GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, rayDistance);
                if (hit.collider)
                {

                    if (hit.collider.gameObject.name == this.gameObject.name && !SPGimick.Instance.SPGimickStart)
                    {
                        Debug.LogWarning(hit.collider.gameObject.name+ this.gameObject.name+ hit.collider.gameObject.name == this.gameObject.name);
                        MouseButtonDown(true,false,0,0,0); RayFlag = true;
                    }
                }
            }
            if (Input.GetMouseButton(0)&&RayFlag)
            {
                MouseButton();
            }
            //else this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            if (Input.GetMouseButtonUp(0)&&RayFlag)
            {
                MouseButtonUp(false);   
            }
        }

    }
    public void AddForces(Vector2 addforcePos)
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(addforcePos);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Scale">初期数値を使用するか</param>
    /// <param name="defaultAddScales">スケール調整時のデフォルト数値を利用するか</param>
    /// <param name="x">大きさ指定</param>
    /// <param name="y">大きさ指定</param>
    /// <param name="AddScales">defaultがfalseの時有効</param>
    public void MouseButtonDown(bool Scale,bool defaultAddScales,float x,float y,float AddScales)
    {
        _Finger.SetActive(true);
        thisPosition = this.transform.position;
        if (Scale)
            FingerPositions.Instance.DefaultScale();
        else
        {
            FingerPositions.Instance.Scales(defaultAddScales,new Vector2(x,y),AddScales);
        }
        cameraPos = CameraFollow.Instance.CameraThisPosition();
        
    }
    public void MouseButton()
    {
        //this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        CameraFollow.Instance.CameraPos(cameraPos);
        this.transform.position = thisPosition;
        FingerPositions.Instance.Scales(true,new Vector2( Vector2.Distance(FingerPositions.Instance.ThisPosition(), thisPosition), Vector2.Distance(FingerPositions.Instance.ThisPosition(), thisPosition)),0);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="SPGminics">真下に向かうギミックの時はtrue</param>
    public void MouseButtonUp(bool SPGminics)
    {
        this.gameObject.GetComponent<Bird>().Attack = true;
        AddForcePos = BirdFingerDistance();
        if (SPGminics)
        {
            if (AddForcePos.y >= 0) return;
            AddForcePos.x = 0;
        }
        Instance.AddForces(AddForcePos * Speed);
        //this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
        FingerPositions.Instance.Actives(false);
        RayFlag = false;
    }
    public Vector2 BirdFingerDistance()
    {
        return thisPosition - FingerPositions.Instance.ThisPosition();
    }
}
