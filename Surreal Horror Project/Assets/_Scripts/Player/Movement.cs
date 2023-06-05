using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speed;
    Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!Input.anyKey) return;

        Vector3 movementVector = transform.TransformVector(new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed));

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

