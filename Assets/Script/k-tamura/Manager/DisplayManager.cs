using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayManager : SingletonMonoBehaviour<DisplayManager>
{
    [SerializeField]
    private Sprite _clear, _fail;


    private void Start()
    {
        Instance.DispInit();
    }
    public void DispMgr(bool Clear)
    {
        if (Clear)
            this.gameObject.GetComponent<Image>().sprite = _clear;
        else
            this.gameObject.GetComponent<Image>().sprite = _fail;
        this.gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
    }
    public void DispInit()
    {
        this.gameObject.GetComponent<Image>().sprite = null;
        this.gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 0);
    }
    
}
