using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerPositions : SingletonMonoBehaviour<FingerPositions>
{
    private float addScale=0.07f;
    private Vector2 tapPosition;
    private Vector2 _DefaultScale;
    private Vector2 _scale;
    [HideInInspector]
    public float mouseDownTime = 0;    
    public Sprite[] allowSprite;
    [HideInInspector]
    public bool HissatsuFlag;
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
    public GameObject getGameObj()
    {
        return this.gameObject;
    }
    /// <summary>
    /// スケール変化
    /// </summary>
    /// <param name="defaults">addScaleのデフォルト数値を利用するか</param>
    /// <param name="scale">Scale</param>
    /// <param name="addScales">defaultsがfalseの時有効</param>
    public void Scales(bool defaults, Vector2 scale, float addScales)
    {
        if (defaults)
        {
            _scale.x = scale.x * addScale;
            _scale.y = scale.y * addScale;
        }
        else
        {
            _scale.x = scale.x * addScales;
            _scale.y = scale.y * addScales;
        }
        this.transform.localScale = _scale;
    }
    public void DefaultScale()
    {
        _DefaultScale.x = 0.04f;
        _DefaultScale.y = 0.04f;
        this.transform.position = _DefaultScale;

    }

    public void AllowColorChange()
    {
        mouseDownTime += Time.deltaTime;

        if (mouseDownTime > 6)
        {
            mouseDownTime = 0;
            HissatsuFlag = false;
        }

        if (mouseDownTime > 4 && 6 >= mouseDownTime)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = allowSprite[2];
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, -90);
            this.gameObject.transform.position = new Vector2(SPGimick.Instance.SPPos.transform.position.x, SPGimick.Instance.SPPos.transform.position.y + 1);
            HissatsuFlag = true;
        }

        if (mouseDownTime > 2 && 4 >= mouseDownTime)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = allowSprite[1];
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, -90);
            this.gameObject.transform.position = new Vector2(SPGimick.Instance.SPPos.transform.position.x, SPGimick.Instance.SPPos.transform.position.y + 1);            
        }

        if (mouseDownTime > 0 && 2 >= mouseDownTime)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = allowSprite[0];
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, -90);
            this.gameObject.transform.position = new Vector2(SPGimick.Instance.SPPos.transform.position.x, SPGimick.Instance.SPPos.transform.position.y + 1);
        }

    }
}
