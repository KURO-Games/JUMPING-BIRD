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
    public float MakeTime = 2f;
    public int MakeMin = 20;
    public int MakeMax = 40;
    public bool CanMakeBuilding = false;
    private void Awake()
    {
        Bird = GameObject.FindGameObjectWithTag("Bird");
    }
    void Start()
    {
        Invoke("MakeZombie", 10f);
    }

    void MakeZombie()
    {
        if (Bird.GetComponent<Bird>().Die == false)
        {
            
            Instantiate(Zombie, new Vector3(Bird.transform.position.x + Random1, -3f, 1f), Quaternion.identity);

            Invoke("MakeZombie", MakeTime);
        }
    }

    void MakeBuilding()
    {
        if (CanMakeBuilding == true)
        {
            Instantiate(Building, new Vector3(Bird.transform.position.x + Random1, 0f, 2f), Quaternion.identity);
            CanMakeBuilding = false;
        }
    }

    void Update()
    {
        Random1 = Random.Range(MakeMin, MakeMax);
        MakeBuilding();
    }
}
