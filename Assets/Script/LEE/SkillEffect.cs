using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    Vector3 size = new Vector3(1, 1, 1);

    [Range(0, 20)]
    public float Speed = 15.0f;

    [Range(0, 5)]
    float D_Time = 1.0f;

    void Update()
    {
        size = size + new Vector3(Time.deltaTime * Speed, Time.deltaTime * Speed, 0);
        transform.localScale = size;
        Destroy(gameObject, D_Time);
    }
}
