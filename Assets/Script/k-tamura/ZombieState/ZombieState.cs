using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieState : MonoBehaviour
{
    public float HitPoint;
    public float RockStr;
    public enum ZombieStatus
    {
        Default,
        Red,
        Green,
        Big
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
}
