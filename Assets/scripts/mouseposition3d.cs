using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseposition3d : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay( Input.mousePosition );
        if (Input.GetMouseButtonDown(1)) { 
            if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                transform.position = raycastHit.point;
            }
        }
    }
}
