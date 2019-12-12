using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPositions : SingletonMonoBehaviour<FingerPositions>
{
    private float addScale=0.07f;
    private Vector2 tapPosition;
    private Vector2 _DefaultScale;
    private Vector2 _scale;
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
    public void Scales(float scale/*Vector2 scale*/)
    {
        _scale.x = scale*addScale;
        _scale.y = scale * addScale;
        this.transform.localScale=_scale;
    }
    public void DefaultScale()
    {
        _DefaultScale.x = 0.04f;
        _DefaultScale.y = 0.04f;
        this.transform.position = _DefaultScale;

    }
}
