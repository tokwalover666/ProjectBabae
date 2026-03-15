using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstPOV;
    [SerializeField] CinemachineVirtualCamera staticPOV;
    [SerializeField] PlayerController playerController;
    bool usingFirst = true;

    void Start()
    {
        usingFirst = true;
        firstPOV.Priority = 10;
        staticPOV.Priority = 5;
    }

    public void ChangePOV()
    {
        usingFirst = !usingFirst;

        if (usingFirst)
        {
            firstPOV.Priority = 10;
            staticPOV.Priority = 5;

            playerController.LockCursor();
        }
        else
        {
            firstPOV.Priority = 5;
            staticPOV.Priority = 10;

            Debug.Log("cursor unlock");
            playerController.UnlockCursor();
        }
    }
}