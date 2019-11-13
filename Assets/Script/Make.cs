using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Make : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Zombie;
    public GameObject Building;
    public float Random1;
    public float Random2;
    public float MakeTime = 1f;
    public int MakeMin = 8;
    public int MakeMax = 40;
    void Start()
    {
        Bird = GameObject.Find("Bird");
        MakeZoB();
    }

    void MakeZoB()
    {
        if (Random1 < 3)
        {
            Instantiate(Zombie, new Vector3(Bird.transform.position.x+ Random2, -3f,1f), Quaternion.identity);
        }
        else
        {
            Instantiate(Building, new Vector3(Bird.transform.position.x+ Random2, 0f,2f), Quaternion.identity);
        }
        Invoke("MakeZoB", MakeTime);
    }

    void Update()
    {
        Random1 = Random.Range(0f, 4f);
        Random2 = Random.Range(MakeMin, MakeMax);
    }
}
