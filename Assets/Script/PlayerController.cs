using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementInput;

    private CharacterController _cc;

    [SerializeField] float playerSpeed;
    [SerializeField] float mouseSensitivity;

    public Transform player;

    float cameraVerticalRotation = 0f;

    bool lockedCursor = true;

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnMove(InputValue iv)
    {
        movementInput = iv.Get<Vector2>();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(movementInput.x, 0.0f, movementInput.y);
        movement = transform.TransformDirection(movement);

        _cc.SimpleMove(movement * playerSpeed);

        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        player.Rotate(Vector3.up * inputX);

        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = new Vector3(cameraVerticalRotation, transform.localEulerAngles.y, 0f);

        cursor();
    }

    void cursor()
    {
        if (Cursor.lockState == CursorLockMode.None && lockedCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            lockedCursor = false;
        }
    }

/*    private void OnApplicationFocus(bool ApplicationIsBack)
    {
        if (ApplicationIsBack == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }*/

}