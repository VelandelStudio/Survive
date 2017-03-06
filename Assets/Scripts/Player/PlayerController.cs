﻿using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

    [Header("Movement Options")]
    [SerializeField]
    private float moveSpeed = 6f;
    [SerializeField]
    private float mouseSensitivity = 3f;

    [SerializeField]
    private float jumpForce = 25f;

    private PlayerMotor playerMotor;

    void Start () {
        playerMotor = GetComponent<PlayerMotor>();
    }

    void Update () {
        CalculateMovement();
		if(Cursor.lockState == CursorLockMode.Locked) {
			CalculateRotation();
			CalculateCameraRotation();
		}
		
        if(Input.GetButtonDown("FurtiveMode"))
        {
            playerMotor.ToggleFurtiveMode();
        }

        if(Input.GetButton("Jump"))
        {
            playerMotor.Jump(jumpForce);
        }
    }

    private void CalculateMovement()
    {
        Vector3 horizontalMovement = Input.GetAxis("Horizontal") * transform.right;
        Vector3 verticalMovement = Input.GetAxis("Vertical") * transform.forward;
        Vector3 velocity = (horizontalMovement + verticalMovement).normalized * moveSpeed;

        playerMotor.MovePlayer(velocity);
    }

    private void CalculateRotation()
    {
		Vector3 horizontalRotation = new Vector3(0, Input.GetAxisRaw("Mouse X"), 0) * mouseSensitivity;
		playerMotor.RotatePlayer(horizontalRotation);
    }

    private void CalculateCameraRotation()
    {
        Vector3 VerticalRotation =- new Vector3(Input.GetAxisRaw("Mouse Y"), 0, 0) * mouseSensitivity;
        playerMotor.RotateCamera(VerticalRotation);
    }
}
