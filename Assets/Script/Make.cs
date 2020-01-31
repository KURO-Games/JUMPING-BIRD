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
    private float _random;
    private float _random2;
    private float spownField;

    [SerializeField]
    private float MakeTime = 2f; 
    
    [SerializeField]
    private GameObject makeLeft;
    [SerializeField]
    private GameObject makeRight;
    [SerializeField]
    private GameObject makeLeft2;
    [SerializeField]
    private GameObject makeRight2
        ;
    public bool CanMakeBuilding = false;
    private int _makeZombies=0, _makeBuildings=0;
    [HideInInspector]
    public bool makeZombies = true;
    
    private void Start()
    {       
        Invoke("MakeZombie", 5f);        
    }

    public void MakeZombie()
    {
        //Debug.Log("SPGimick.Instance.SPGimickStart" + SPGimick.Instance.SPGimickStart);
        //Debug.Log("Bird.Instance.Die" + Bird.Instance.Die);
        if (!Bird.Instance.Die && !SPGimick.Instance.SPGimickStart && makeZombies)
        {
            if (ZombieQTY < ZombieMax)
            {
                _random = Random.Range(makeLeft.transform.position.x, makeRight.transform.position.x + 5);
                _random2 = Random.Range(makeLeft2.transform.position.x - 5, makeRight2.transform.position.x + 10);
                spownField = Random.Range(_random, _random);
                GameObject _zombie = Instantiate(Zombie, new Vector3(Bird.Instance.bird().transform.position.x + spownField, -5f, 1f), Quaternion.identity);
                _zombie.gameObject.GetComponent<ZombieState>()._zombieStatus = ZombieState.ZombieStatus.Default;
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
            GameObject _building = Instantiate(Building, new Vector3(Bird.Instance.bird().transform.position.x + spownField, -2f, 2f), Quaternion.identity);
            _building.name = Building.name+_makeBuildings.ToString();
            _makeBuildings++;
            _building.transform.parent = Buildings.transform;
            CanMakeBuilding = false;
        }
    }

    void Update()
    {        
        MakeBuilding();
    }
}
