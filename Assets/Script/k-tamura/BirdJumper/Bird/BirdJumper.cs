using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJumper : SingletonMonoBehaviour<BirdJumper>
{
    private Vector2 thisPosition;
    private Vector2 AddForcePos;
    private Vector3 cameraPos;
    private Vector2 distance;

[SerializeField]
    private float Speed=2;
    [SerializeField]
    private GameObject _Finger;
    private void Update()
    {
        if (this.GetComponent<Bird>().FirstJumpLimit)
        {
            Debug.LogWarning(Bird.Instance.FirstJumpLimit);
            if (Input.GetMouseButtonDown(0))
            {
                _Finger.SetActive(true);
                thisPosition = this.transform.position;
                FingerPositions.Instance.DefaultScale();
                cameraPos = CameraFollow.Instance.CameraThisPosition();
            }
            if (Input.GetMouseButton(0))
            {
                this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                CameraFollow.Instance.CameraPos(cameraPos);
                this.transform.position = thisPosition;
                FingerPositions.Instance.Scales(Vector2.Distance(FingerPositions.Instance.ThisPosition(),thisPosition));
            }
            else this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            if (Input.GetMouseButtonUp(0))
            {
                
                this.gameObject.GetComponent<Bird>().Attack = true;
                AddForcePos = thisPosition - FingerPositions.Instance.ThisPosition();
                Instance.AddForces(AddForcePos*Speed);
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
                FingerPositions.Instance.Actives(false);
            }
        }

    }
    public void AddForces(Vector2 addforcePos)
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(addforcePos);
    }
}
