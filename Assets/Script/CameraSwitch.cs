using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstPOV;
    [SerializeField] CinemachineVirtualCamera staticPOV;
    [SerializeField] PlayerController playerController;
    [SerializeField] FragmentsManager fragmentsManager;
    bool usingFirst;
    Animator anim;
    void Start()
    {
        GameObject barText = GameObject.Find("TAB");
        anim = barText.GetComponent<Animator>();

        usingFirst = true;
        firstPOV.Priority = 10;
        staticPOV.Priority = 5;
    }

    public void ChangePOV()
    {
        usingFirst = !usingFirst;

        if (usingFirst)
        {
            if (FragmentsManager.roomComplete == true)
            {
                anim.SetBool("isGlowing", true);
            }
            firstPOV.Priority = 10;
            staticPOV.Priority = 5;

            playerController.LockCursor();

            if (fragmentsManager != null)
                fragmentsManager.ShowPortraitForCurrentRoom(false);
        }
        else
        {
            anim.SetBool("isGlowing", false);

            firstPOV.Priority = 5;
            staticPOV.Priority = 10;

            playerController.UnlockCursor();

            if (fragmentsManager != null)
                fragmentsManager.ShowPortraitForCurrentRoom(true);
        }
    }
}