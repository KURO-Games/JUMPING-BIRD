using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Rock;
    public bool ZAttack = false;

    void Start()
    {
        Bird = GameObject.Find("Bird");
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
            Instantiate(Rock, InstantiateRock, Quaternion.identity);
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
