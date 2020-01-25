using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Make : SingletonMonoBehaviour<Make>
{
    [SerializeField]
    private GameObject Zombie;
    [SerializeField]
    private GameObject Building;
    [Header("子オブジェクト追加")]
    [SerializeField]
    private GameObject Zombies, Buildings;
    [SerializeField]
    private int ZombieMax = 10;
    [HideInInspector]
    public int ZombieQTY = 0;
    [HideInInspector]
    public int ZombieCount = 0;
    [Header("")]
    public float Random1;
    public float MakeTime = 2f;
    public int MakeMin = 20;
    public int MakeMax = 40;
    public bool CanMakeBuilding = false;
    private int _makeZombies=0, _makeBuildings=0;
    [HideInInspector]
    public bool makeZonbies;
    private void Start()
    {       
        Invoke("MakeZombie", 5f);
    }

    public void MakeZombie()
    {
        //Debug.Log("SPGimick.Instance.SPGimickStart" + SPGimick.Instance.SPGimickStart);
        //Debug.Log("Bird.Instance.Die" + Bird.Instance.Die);
        if (Bird.Instance.Die == false && !SPGimick.Instance.SPGimickStart && makeZonbies)
        {
            if (ZombieQTY < ZombieMax)
            {
                GameObject _zombie = Instantiate(Zombie, new Vector3(Bird.Instance.bird().transform.position.x + Random1, -5f, 1f), Quaternion.identity);
                ZombieQTY += 1;
                ZombieCount++;
                _zombie.name = Zombie.name + _makeZombies.ToString();
                _makeZombies++;
                _zombie.transform.parent = Zombies.transform;
            }
            Invoke("MakeZombie", MakeTime);
        }
    }

    void MakeBuilding()
    {
        if (CanMakeBuilding == true && !SPGimick.Instance.SPGimickStart)
        {
            GameObject _building = Instantiate(Building, new Vector3(Bird.Instance.bird().transform.position.x + Random1, -2f, 2f), Quaternion.identity);
            _building.name = Building.name+_makeBuildings.ToString();
            _makeBuildings++;
            _building.transform.parent = Buildings.transform;
            CanMakeBuilding = false;
        }
    }

    void Update()
    {
        Random1 = Random.Range(MakeMin, MakeMax);
        MakeBuilding();
    }
}
