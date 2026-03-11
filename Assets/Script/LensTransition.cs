using UnityEngine;
using System.Collections;

public class LensTransition : MonoBehaviour
{
    [SerializeField] GameObject mainScreen;

    [SerializeField] Animator animator;
    [SerializeField] CameraSwitch cameraSwitch;

    private bool isTransitioning = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isTransitioning)
        {

            StartCoroutine(SpaceStart());
        }
    }

    public IEnumerator SpaceStart()
    {
        isTransitioning = true;

        if (mainScreen.activeSelf)
        {
            animator.SetTrigger("Transition");

            yield return new WaitForSeconds(1.3f);

            cameraSwitch.ChangePOV();
        }

        isTransitioning = false;
    }
}
