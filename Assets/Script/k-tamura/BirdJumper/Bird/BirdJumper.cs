using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJumper : SingletonMonoBehaviour<BirdJumper>
{
    private Vector2 thisPosition;
    private Vector2 AddForcePos;
    [SerializeField]
    private float Speed=2;
    [SerializeField]
    private GameObject _Finger;
    private void Update()
    {
        if (this.GetComponent<Bird>().Fly)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _Finger.SetActive(true);
                thisPosition = this.transform.position;
            }
            if (Input.GetMouseButton(0))
            {
                this.transform.position = thisPosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                this.gameObject.GetComponent<Bird>().Attack = true;
                AddForcePos = thisPosition - FingerPositions.Instance.ThisPosition();
                Instance.AddForces(AddForcePos*Speed);
                FingerPositions.Instance.Actives(false);
            }
        }

    }
    public void AddForces(Vector2 addforcePos)
    {
        this.gameObject.GetComponent<Rigidbody2D>().AddForce(addforcePos);
    }
}
