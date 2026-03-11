using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstPOV;
    [SerializeField] CinemachineVirtualCamera staticPOV;

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
        }
        else
        {
            firstPOV.Priority = 5;
            staticPOV.Priority = 10;
        }
    }
}