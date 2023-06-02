using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region
    public static Player instance
    {
        get
        {
            return _instance;
        }
    }
    public static Player _instance;
    private void Awake()
    {
        _instance = this;
    }
    #endregion

    //public Transform itemTransform;

    [SerializeField] Camera mainCam;
    [SerializeField] Camera falseCam;

    public LayerMask layer;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            RaycastCheck();
        }
    }

    void RaycastCheck()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, 1.5f, layer))
        {
            if(hit.transform.gameObject.TryGetComponent<IInteractable>(out IInteractable interactable))
            {
                interactable.Interact(transform);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit Something");
        StartCoroutine(SwitchCameras());
    }

    IEnumerator SwitchCameras()
    {
        falseCam.gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        falseCam.gameObject.SetActive(true);
    }
}
