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
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        Vector3 moveAmount = transform.rotation * velocity;
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);

        // rotate with camera
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
    }

    bool IsGrounded()
    {
        float rayLength = col.bounds.extents.y + 0.1f;
        bool isGrounded = Physics.Raycast(transform.position, -Vector3.up, rayLength);
        return isGrounded;
    }
}
