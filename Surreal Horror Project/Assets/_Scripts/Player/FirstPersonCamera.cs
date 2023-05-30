using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] Transform camTransform;
    public float Sensitivity;

    float xRot;
    float yRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        yRot = Input.GetAxis("Mouse X");
        xRot = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, yRot);
        camTransform.transform.Rotate(Vector3.right, -xRot);
    }
}
