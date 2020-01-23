using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int Kill = 0;
    [SerializeField]
    private GameObject Bird;
    [SerializeField]
    private GameObject Make;
    bool DeBug = false; //debug用

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Kill + " / " + Bird.GetComponent<Bird>().ZombieKill;

        if(Kill == Bird.GetComponent<Bird>().ZombieKill)
        {
            Destroy(Make.GetComponent<Make>());

            if (DeBug == false)//debug用
            {
                //Debug.Log("ゾンビを倒しました！");
                DeBug = true;
            }
        }
    }
}
