using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState : MonoBehaviour
{
    public float HitPoint;
    public float RockStr;
    private float _time;
    public enum ZombieStatus
    {
        Default,
        Red,
        Green,
        Big
    }
    public enum AnimatorState
    {
        Attack,
        Die
    }
    private void Update()
    {
        _time = +Time.deltaTime;  
    }
    public ZombieStatus _zombieStatus;
    private void Start()
    {
        switch (_zombieStatus)
        {
            case ZombieStatus.Big:
                HitPoint = 3;
                RockStr = 2;
                break;
            case ZombieStatus.Red:
                HitPoint = 1;
                RockStr = 2;
                break;
            case ZombieStatus.Green:
                HitPoint = 2;
                RockStr = 1;
                break;
            case ZombieStatus.Default:
                HitPoint = 1;
                RockStr = 1;
                break;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bird")
        {
            HitPoint--;
            if (HitPoint <= 0)
            {
                this.gameObject.GetComponent<Animator>().SetTrigger("");
            }
            else
            {

            }
        } 
    }
}
