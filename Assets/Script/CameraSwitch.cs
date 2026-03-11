using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera firstPOV;
    public CinemachineVirtualCamera staticPOV;

    bool usingFirst = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            usingFirst = !usingFirst;

            if (usingFirst)
            {
                firstPOV.Priority = 10;
                staticPOV.Priority = 5;
            }
            else
            {
                firstPOV.Priority = 5;
                staticPOV.Priority = 10;
            }
        }
    }
}