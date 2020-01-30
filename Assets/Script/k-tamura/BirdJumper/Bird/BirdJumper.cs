using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJumper : SingletonMonoBehaviour<BirdJumper>
{
    Vector2 ThisTransformPos;
    private Vector2 thisPosition;
    private Vector2 AddForcePos;
    private Vector3 cameraPos;
    [SerializeField]
    private float Speed=2;
    [SerializeField]
    private GameObject _Finger;
    [HideInInspector]
    public bool groundCheck;
    
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))//RayでBirdがタップされているか処理
        {
            Bird.Instance.Fly = true;
            ThisTransformPos = gameObject.transform.position;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
            MouseButtonDown();
        }
        if (Input.GetMouseButton(0))
        {
            gameObject.transform.position = ThisTransformPos;
            MouseButton();
        }
        //else this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        if (Input.GetMouseButtonUp(0))
        {
            Bird.Instance.Attack = true;
            MouseButtonUp(false);
            BirdAnimationController.BirdAnimations(BirdAnimationController.BirdAnimParam.FlyUp);
        }


    }
    

    /// <summary>
    /// Addforce
    /// </summary>
    /// <param name="addforcePos"></param>
    public void AddForces(Vector2 addforcePos)
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(addforcePos);
    }
    /// <summary>
    /// Mouseボタン押した時
    /// </summary>
    public void MouseButtonDown()
    {
        _Finger.SetActive(true);
        FingerPositions.Instance.transform.localPosition=new Vector3(0, 0, 0);
        thisPosition = Input.mousePosition;
        FingerPositions.Instance.DefaultScale();
        cameraPos = CameraFollow.Instance.CameraThisPosition();
        
    }/// <summary>
    /// Mouseボタンが押しっぱなし処理
    /// </summary>
    public void MouseButton()
    {
       
        CameraFollow.Instance.CameraPos(cameraPos);
        FingerPositions.Instance.Scales(false,new Vector2( Vector2.Distance(Input.mousePosition, thisPosition), Vector2.Distance(Input.mousePosition, thisPosition)),0.001f);
    }
    /// <summary>
    /// Mouseボタン離した時
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

        _Finger.SetActive(false);
    }
    public Vector2 BirdFingerDistance()
    {
        return thisPosition - (Vector2)Input.mousePosition;
    }
}
