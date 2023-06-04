using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    Rigidbody rb;

    void Update()
    {
        rb = GetComponent<Rigidbody>();
        SetAnimParameters();
    }

    void SetAnimParameters()
    {
        animator.SetFloat("X", transform.InverseTransformDirection(rb.velocity).x);
        animator.SetFloat("Y", transform.InverseTransformDirection(rb.velocity).z);
    }
}
