using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Make : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Zombie;
    public GameObject Building;
    public float Random1 = 1;
    public float Random2 = 10;
    void Start()
    {
        Bird = GameObject.Find("Bird");
        MakeZoB();
    }

    void MakeZoB()
    {
        if (Random1 < 1)
        {
            Instantiate(Zombie, new Vector3(Bird.transform.position.x+ Random2, -2.8f,1f), Quaternion.identity);
        }
        else
        {
            Instantiate(Building, new Vector3(Bird.transform.position.x+ Random2, -1.2f,2f), Quaternion.identity);
        }
        Invoke("MakeZoB", 0.2f);
    }

    void Update()
    {
        Random1 = Random.Range(0f, 2f);
        Random2 = Random.Range(8f, 40f);
    }
}
