using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    public GameObject Rock;
    public static int speed = 1;
    ZonbieState _zonbieState;
    enum ZonbieState
    {
        Wait,
        Attack,
        Die,
    }
    void Awake()
    {
        
    }
    private void Start()
    {
        _zonbieState = ZonbieState.Wait;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (Bird.Instance.Die == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(Bird.Instance.bird().transform.position.x, this.transform.position.y), step);
            if (gameObject.transform.position.x + 5 > Bird.Instance.bird().transform.position.x && gameObject.transform.position.x - 5 < Bird.Instance.bird().transform.position.x)
            {
                RockAttack();
            }
        }
    }
    void AttackReset()
    {
        _zonbieState = ZonbieState.Wait;
    }

    void RockAttack()
    {        
        Debug.Log("RockAttack");
        if (_zonbieState==ZonbieState.Wait && !SPGimick.Instance.SPGimickStart)
        {
            Vector2 InstantiateRock;
            InstantiateRock.x = this.gameObject.transform.position.x - 1;
            InstantiateRock.y = this.gameObject.transform.position.y - 1;
            GameObject _Rockinstance = Instantiate(Rock, InstantiateRock, Quaternion.identity);
            _Rockinstance.name = Rock.name + this.gameObject.name;
            _zonbieState = ZonbieState.Attack;
            Invoke("AttackReset", 3f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Zombie" && )
        {

        }
    }
}
