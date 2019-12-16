using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finger : SingletonMonoBehaviour<Finger>
{
    private bool Over = false;
    private bool Limit = true;
    Vector3 rotat;
    IEnumerator JumpLimitSet()
    {
        yield return new WaitForSeconds(0.5f);
        Limit = false;
    }
    
    private void Update()
    {
        if (SPGimick.Instance.SPGimickStart) return;
        rotat.z = AngleCal(this.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition))+180;
        this.transform.rotation=Quaternion.Euler(rotat);
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(JumpLimitSet());
        }
    }
    
    private float AngleCal(Vector2 startpos,Vector2 targetpos)
    {
        Vector2 dt = targetpos - startpos;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;
        return degree;
    }
}

