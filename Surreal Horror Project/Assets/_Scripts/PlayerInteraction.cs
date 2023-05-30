using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    Camera mainCam;
    public LayerMask mask;

    private void Start()
    {
        mainCam = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit, 12, mask))
            {
                if(hit.transform.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact(transform);
                }
            }
        }    
    }
}
