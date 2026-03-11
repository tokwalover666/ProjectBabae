using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform sceneCamera;

    [SerializeField] private LayerMask pickUpLM;

    private ObjectGrabbable objGrabbable;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (objGrabbable == null)
            {
                float pickUpDistance1 = 2f;
                
                if (Physics.Raycast(sceneCamera.position, sceneCamera.forward, out RaycastHit rraycastHit, pickUpDistance1, pickUpLM))
                {
                    if (rraycastHit.transform.TryGetComponent(out objGrabbable))
                    {
                        objGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(objGrabbable);
                    }
                }
            }
            else
            {
                objGrabbable.Drop();
                objGrabbable = null;
            }
        }
    }


}
