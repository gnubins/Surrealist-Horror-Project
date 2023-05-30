using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform teleportTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportTransform();
        }
    }

    private void Update()
    {
        teleportTarget.position = new Vector3(teleportTarget.position.x, target.position.y + 0.001f, target.position.z);
    }

    void TeleportTransform()
    {
        target.position = teleportTarget.position;
    }
}
