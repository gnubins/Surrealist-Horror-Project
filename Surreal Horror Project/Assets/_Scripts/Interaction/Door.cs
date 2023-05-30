using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    Rigidbody rb;
    bool isOpen = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {

    }

    public void Interact(Transform interacter)
    {
        //if (isOpen)
        //{
        //    rb.AddTorque(transform.forward * 45);
        //}
        //else
        //{
        //    rb.isKinematic = false;
        //    rb.AddTorque(transform.forward * -45);
        //}
        //isOpen = !isOpen;
        rb.AddTorque(transform.forward * -45);

    }


}
