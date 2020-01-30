using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapMgr : SingletonMonoBehaviour<TapMgr>
{
    public Vector2 FirstTapPoint, EndTapPoint;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FirstTapPoint = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            EndTapPoint = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {

        }

    }
}
