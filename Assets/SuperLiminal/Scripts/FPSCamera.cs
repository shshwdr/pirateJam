using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 90.0f;
    public Transform rotationTarget;

    [Range(0.0f, 1.0f)]
    public float drag = 0.1f;

    private Rigidbody rb;
    private Vector3 lastMousePos;
    private Vector3 currentRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        lastMousePos = Input.mousePosition;
        currentRotation = rotationTarget.rotation.eulerAngles;
        rb.freezeRotation = true; // Prevent Rigidbody from controlling rotation
    }

    void FixedUpdate()
    {
        Vector3 f = rotationTarget.forward;
        f.y = 0.0f; 
        f.Normalize();
        
        Vector3 r = rotationTarget.right;
        r.y = 0.0f; 
        r.Normalize();

        Vector3 newVelocity = f * Input.GetAxis("Vertical") * moveSpeed + r * Input.GetAxis("Horizontal") * moveSpeed;

        newVelocity *= (1.0f - drag);

        rb.velocity = newVelocity;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentRotation = Vector3.zero;
            ;
        }
        Vector2 mouseDelta = (Vector2)Input.mousePosition - (Vector2)lastMousePos;
        lastMousePos = Input.mousePosition;

        currentRotation.y += mouseDelta.x * rotateSpeed * Time.deltaTime;
        currentRotation.x = Mathf.Clamp(currentRotation.x - mouseDelta.y * rotateSpeed * Time.deltaTime, -70.0f, 70.0f);

        rotationTarget.rotation = Quaternion.Lerp(rotationTarget.rotation, Quaternion.Euler(currentRotation), Time.deltaTime * rotateSpeed);
    }
}