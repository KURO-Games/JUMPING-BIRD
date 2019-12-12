using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : SingletonMonoBehaviour<Life>
{
    
    [SerializeField]
    private GameObject _Life1, _Life2, _Life3;
    public int LifeNum;
    public Sprite Life1;
    public Sprite Life0;

    void Update()
    {
        if (Bird.Instance.Life >= 1)
            _Life1.GetComponent<Image>().sprite = Life1;
        else
            _Life1.GetComponent<Image>().sprite = Life0;
        if (Bird.Instance.Life >= 2)
            _Life2.GetComponent<Image>().sprite = Life1;
        else
            _Life2.GetComponent<Image>().sprite = Life0;
        if (Bird.Instance.Life >= 3)
            _Life3.GetComponent<Image>().sprite = Life1;
        else
            _Life3.GetComponent<Image>().sprite = Life0;

    }
}

