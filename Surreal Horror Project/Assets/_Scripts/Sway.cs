using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    private Transform _transform;

    [SerializeField]
    float snappiness = 5;
    [SerializeField]
    float swayMultiplier = 2;

    Vector2 inputVector2;

    void Start() => _transform = transform;

    void Update()
    {
        //_transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.Euler(Vector3.zero), _returnRate);

        Quaternion xRotation = Quaternion.AngleAxis(inputVector2.x, Vector3.right);
        Quaternion zRotation = Quaternion.AngleAxis(inputVector2.y, Vector3.forward);

        Quaternion targetRot = xRotation * zRotation;

        _transform.localRotation = Quaternion.Slerp(_transform.localRotation, targetRot, snappiness * Time.deltaTime);
    }

    public void UpdateRotation (Vector2 vector2)
    {
        inputVector2 = vector2 * swayMultiplier;   
    }
}
