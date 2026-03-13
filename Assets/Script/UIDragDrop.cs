using UnityEngine;
using TMPro;

public class UIDragDrop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;

    [SerializeField] Transform sceneCamera;

    [SerializeField] LayerMask pickUpLM;

    private ObjectGrabbable objGrabbable;

    private bool hasObjectDetected = true;

    private void Update()
    {
        float pickUpDistance = 2f;
        if (Physics.Raycast(sceneCamera.position, sceneCamera.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLM))
        {
            if (raycastHit.transform.TryGetComponent(out objGrabbable) && hasObjectDetected == true)
            {
                textMesh.text = "Pick Up";

                if (Input.GetMouseButtonDown(0) )
                {
                    textMesh.text = "Drop";
                    hasObjectDetected = false;
                }
            }
        }
        else
        {
            hasObjectDetected = true;
            textMesh.text = "";
        }
    }
}
