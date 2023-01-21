using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    // 1. Move in locap space directions with arrow keys
    // 2. Camera follows mouse
    public Transform playerTransform;
    public CharacterController playerCharacterController;
    public float sensitivity = 1;
    public float speed = 5;

    // Camera axes
    float pitch = 0;
    float yaw = 0;

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        MovePlayer();
    }

    void RotateCamera()
    {
        // Add or subtract rotation based on where the mouse is moving
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        Vector3 targetPlayerRotation = new Vector3(0, yaw);
        //Mathf.Clamp(targetPlayerRotation, -90, 90);
        playerTransform.eulerAngles = targetPlayerRotation;

        Vector3 targetCameraRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetCameraRotation;


    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Vector3 vel = playerTransform.forward * v + playerTransform.right * h + Vector3.down;
        playerCharacterController.Move(vel);
    }
}

