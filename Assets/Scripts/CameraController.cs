using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float verticalRotationRange = 60f;
    float mouseSensitivity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        // Rotate horizontally around the target object
        transform.RotateAround(target.position, Vector3.up, mouseX);

        // Rotate vertically around the target object within the specified range
        float currentXRotation = transform.eulerAngles.x;
        float newVerticalRotation = currentXRotation - mouseY;
        transform.eulerAngles = new Vector3(newVerticalRotation, transform.eulerAngles.y, 0);

        // Clamp the vertical rotation between the specified range
        if (newVerticalRotation > verticalRotationRange && newVerticalRotation < 360 - verticalRotationRange)
        {
            transform.eulerAngles = new Vector3(verticalRotationRange, transform.eulerAngles.y, 0);
        }
    }

    void FixedUpdate()
    {
        // update position based on target position, target rotation
        Vector3 desiredPosition = target.position + transform.rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
