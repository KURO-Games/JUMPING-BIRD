using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimatorController : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

}
