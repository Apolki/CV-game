using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1f, 100f)] [SerializeField] float movementSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float jumpForce = 3f;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform raycastOrigin;

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = 4f;
        }
        */
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 105.0f * rotationSpeed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f * movementSpeed;
        transform.Rotate(xAngle: 0, yAngle: x, zAngle: 0);
        transform.Translate(x: 0, y: 0, z);
        if (Input.GetKeyDown(KeyCode.Space) && canIjump())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool canIjump()
    {
        return Physics.Raycast(raycastOrigin.position, direction: Vector3.down, maxDistance: 0.1f);
    }

}
