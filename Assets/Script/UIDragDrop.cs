using UnityEngine;
using TMPro;

public class UIDragDrop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] Transform sceneCamera;
    [SerializeField] LayerMask pickUpLM;

    private ObjectGrabbable objGrabbable;
    private bool holdingObject = false;

    private void Update()
    {
        float pickUpDistance = 2f;

        if (!holdingObject)
        {
            if (Physics.Raycast(sceneCamera.position, sceneCamera.forward, out RaycastHit hit, pickUpDistance, pickUpLM))
            {
                ObjectGrabbable target;

                if (hit.transform.TryGetComponent(out target))
                {
                    textMesh.text = "Pick Up";

                    if (Input.GetMouseButtonDown(0))
                    {
                        objGrabbable = target;
                        holdingObject = true;
                        textMesh.text = "";
                    }
                }
            }
            else
            {
                textMesh.text = "";
            }
        }
        else
        {
            if (objGrabbable != null && objGrabbable.CanBePlaced())
            {
                textMesh.text = "Drop";

                if (Input.GetMouseButtonDown(0))
                {
                    holdingObject = false;
                    objGrabbable = null;
                    textMesh.text = "";
                }
            }
            else
            {
                textMesh.text = "";
            }
        }
    }
}