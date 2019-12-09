using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    public GameObject Bird,Rock;
    public bool ZAttack = false;

    void Awake()
    {
        Bird = GameObject.FindGameObjectWithTag("Bird");
    }

    void AttackReset()
    {
        ZAttack = false;
    }

    void RockAttack()
    {
        if (ZAttack == false)
        {
            Vector2 InstantiateRock;
            InstantiateRock.x = this.gameObject.transform.position.x-1;
            InstantiateRock.y = this.gameObject.transform.position.y - 1;
            GameObject _Rockinstance = Instantiate(Rock, InstantiateRock, Quaternion.identity);
            _Rockinstance.name = Rock.name+this.gameObject.name;
            ZAttack = true;
            Invoke("AttackReset", 3f);
        }
    }

    void Update()
    {
        if (Bird.GetComponent<Bird>().Die == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(Bird.transform.position.x, -2.8f), Time.deltaTime);
            if (gameObject.transform.position.x + 5 > Bird.transform.position.x && gameObject.transform.position.x - 5 < Bird.transform.position.x)
            {
                RockAttack();
            }
        }
    }
}
