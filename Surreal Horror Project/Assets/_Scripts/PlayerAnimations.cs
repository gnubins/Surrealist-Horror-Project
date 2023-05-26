    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Sway sway;
    Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        SetAnimations();
        SwayCamera();
    }

    void SetAnimations()
    {
        //animator.SetFloat("Speed", movement.velocityMag);
        //animator.SetBool("Grounded", movement.grounded);
    }

    void SwayCamera()
    {
        Vector3 _vector3 = movement.inputVector;
        sway.UpdateRotation(new Vector2( _vector3.z, -_vector3.x));
    }

}
