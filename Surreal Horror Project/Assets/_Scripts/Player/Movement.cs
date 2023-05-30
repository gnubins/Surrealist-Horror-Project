using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 movementVector = transform.TransformVector(new Vector3(Input.GetAxis("Horizontal") * 3, rb.velocity.y, Input.GetAxis("Vertical") * 3));

        rb.velocity = movementVector; 
    }

    void Jump()
    {

    }

    public Vector3 GetRigibodyVelocity()
    {
        return rb.velocity;
    }

}

