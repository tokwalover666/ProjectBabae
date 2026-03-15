using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform sceneCamera;
    [SerializeField] private LayerMask pickUpLM;

    private ObjectGrabbable objGrabbable;

    private void Update()
    {
        float pickUpDistance = 2f;

        if (objGrabbable == null)
        {
            if (Physics.Raycast(sceneCamera.position, sceneCamera.forward, out RaycastHit hit, pickUpDistance, pickUpLM))
            {
                if (hit.transform.TryGetComponent(out ObjectGrabbable target))
                {
                    textMesh.text = "Pick Up";

                    if (Input.GetMouseButtonDown(0))
                    {
                        objGrabbable = target;
                        objGrabbable.Grab(objectGrabPointTransform);
                    }
                }
                else
                {
                    textMesh.text = "";
                }
            }
            else
            {
                textMesh.text = "";
            }
        }
        else
        { 
            if (Input.GetMouseButtonDown(0))
            {
                objGrabbable.Drop();
                objGrabbable = null;
            }
             
            if (objGrabbable != null && objGrabbable.CanBePlaced())
            {
                textMesh.text = "Drop";
            }
            else
            {
                textMesh.text = "";
            }
        }
    }

}
