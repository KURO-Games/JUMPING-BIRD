using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

}
