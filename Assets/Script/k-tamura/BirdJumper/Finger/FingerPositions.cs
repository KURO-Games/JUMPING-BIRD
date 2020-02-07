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
            _scale.y = this.transform.localScale.y;
        }
        else
        {
            _scale.x = scale.x * addScales;
            _scale.y = this.transform.localScale.y;
           
        }

        this.transform.localScale = _scale;
    }
    /// <summary>
    /// defaultScale
    /// </summary>
    public void DefaultScale()
    {
        _DefaultScale.x = 0.04f;
        _DefaultScale.y = this.transform.localScale.y;
        this.transform.localScale = _DefaultScale;

    }
    /// <summary>
    /// Attack時のsprite変更
    /// </summary>
    public void AllowColorChange()
    {
        mouseDownTime += Time.deltaTime;

        if (mouseDownTime > 6)
        {
            mouseDownTime = 0;
            SPGimick.Instance.HissatsuFlag = false;
            SPGimick.Instance.goUI.gameObject.SetActive(false);
        }

        if (mouseDownTime > 4 && 6 >= mouseDownTime)
        {
            //Debug.Log(SPGimick.Instance.HissatsuFlag);
            SPGimick.Instance.goUI.gameObject.SetActive(true);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = allowSprite[2];
            this.gameObject.transform.localRotation = Quaternion.Euler(0, 0, -90);
            this.gameObject.transform.position = new Vector2(SPGimick.Instance.SPPos.transform.position.x, SPGimick.Instance.SPPos.transform.position.y + 1);
            SPGimick.Instance.HissatsuFlag = true;
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
