using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPositions : SingletonMonoBehaviour<FingerPositions>
{
    private Vector2 tapPosition;

    private void Update()
    {
        tapPosition = this.gameObject.transform.position;
        
    }

    public Vector2 ThisPosition()
    {
        return Instance.tapPosition;
    }
    public void Actives(bool active)
    {
        this.gameObject.SetActive(active);
    }
}
