using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : SingletonMonoBehaviour<Life>
{
    public GameObject Bird;
    public int LifeNum = 3;
    public Sprite Life1;
    public Sprite Life0;

    void Start()
    {
        Bird = GameObject.FindGameObjectWithTag("Bird");
    }

    
    void Update()
    {
        if (LifeNum == 1)
        {
            if (Bird.GetComponent<Bird>().Life >= 1)
            {
                this.GetComponent<Image>().sprite = Life1;
            }
            else
            {
                this.GetComponent<Image>().sprite = Life0;
            }
        }
        if (LifeNum == 2)
        {
            if (Bird.GetComponent<Bird>().Life >= 2)
            {
                this.GetComponent<Image>().sprite = Life1;
            }
            else
            {
                this.GetComponent<Image>().sprite = Life0;
            }
        }
        if (LifeNum == 3)
        {
            if (Bird.GetComponent<Bird>().Life >= 3)
            {
                this.GetComponent<Image>().sprite = Life1;
            }
            else
            {
                this.GetComponent<Image>().sprite = Life0;
            }
        }



    }
}
