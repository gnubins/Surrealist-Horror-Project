using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    Transform playerTransform;
    float rot = 90;
    Vector3 rotToVec;


    void Start()
    {
        playerTransform = Player.instance.transform;
        rotToVec = new Vector3(0, Mathf.Deg2Rad*rot, 0);

    }

    void LateUpdate()
    {
        //Vector3 direction = transform.position - playerTransform.position;
        //Vector3 newDir = new Vector3(direction.x * direction.x, direction.y * direction.y, direction.z * direction.z) ;
        //transform.rotation = Quaternion.LookRotation(newDir);
        //Debug.DrawRay(transform.position, transform.forward);
    }
}
