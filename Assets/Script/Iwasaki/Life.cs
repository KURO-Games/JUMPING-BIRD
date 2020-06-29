using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : SingletonMonoBehaviour<Life>
{
    
    [SerializeField]
    private GameObject Life1, Life2, Life3;
    [SerializeField]
    private Sprite pureHeart;
    [SerializeField]
    private Sprite DamageHeart;

    void Update()
    {
        if (Bird.Instance.Life >= 1)
            Life1.GetComponent<Image>().sprite = pureHeart;
        else
            Life1.GetComponent<Image>().sprite = DamageHeart;

        if (Bird.Instance.Life >= 2)
            Life2.GetComponent<Image>().sprite = pureHeart;
        else
            Life2.GetComponent<Image>().sprite = DamageHeart;

        if (Bird.Instance.Life >= 3)
            Life3.GetComponent<Image>().sprite = pureHeart;
        else
            Life3.GetComponent<Image>().sprite = DamageHeart;

    }
}

