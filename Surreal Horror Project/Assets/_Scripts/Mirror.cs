using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] Transform mirrorCam;


    bool enableMirror;

    void Start()
    {
    }

    private void LateUpdate()
    {
        mirrorCam.localPosition = MirrorPosition(transform.InverseTransformPoint(playerCam.position));
        //Vector3 direction = 
        //mirrorCam.rotation = Quaternion.Euler(direction);
        mirrorCam.rotation = Quaternion.Euler(0,  -90 - mirrorCam.localPosition.z  * 13 ,0);
    }
 
    Vector3 MirrorPosition(Vector3 point)
    {
        Vector3 originPoint =  point;
        return new Vector3(originPoint.x * -1, originPoint.y,originPoint.z ) ;
    }
}
