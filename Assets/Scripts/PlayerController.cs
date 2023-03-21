using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    float jumpForce = 10.0f;
    float mouseSensitivity = 10.0f;

    Rigidbody rb;
    CapsuleCollider col;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // rotate player with mouse, move forward and backward base on rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
    }

    bool IsGrounded()
    {
        float rayLength = col.bounds.extents.y + 0.1f;
        bool isGrounded = Physics.Raycast(transform.position, -Vector3.up, rayLength);
        return isGrounded;
    }
}
