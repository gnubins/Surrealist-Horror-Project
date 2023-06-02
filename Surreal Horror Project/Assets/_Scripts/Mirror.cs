using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    Transform player;
   [SerializeField] Transform mirrorCam;

    float rot = 90;
    Vector3 rotToVec;

    bool enableMirror;

    void Start()
    {
        player = Player.instance.transform;
        rotToVec = new Vector3(0, Mathf.Deg2Rad*rot, 0);
    }

    void LateUpdate()
    {

    }

    public void Render()
    {
        var m = player.transform.worldToLocalMatrix * transform.worldToLocalMatrix ;  
    }
}
