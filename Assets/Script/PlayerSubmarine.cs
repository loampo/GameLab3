using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubmarine : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float sidewaysSpeed = 5f;
    public float rotationSpeed = 100f;
    public float verticalSpeed = 5f;

    private Rigidbody rb;
    private bool invertMouse = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Max Speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 50f);

        // Move forward/backward
        float forwardInput = Input.GetAxis("Vertical");
        float sidewaysInput = Input.GetAxis("Horizontal");
        Vector3 forwardDirection = transform.forward;
        Vector3 moveDirection = forwardDirection * forwardInput * forwardSpeed;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            rb.AddForce(moveDirection);
        }

        // Move sideways
        Vector3 sidewaysDirection = transform.right;
        Vector3 moveSideways = sidewaysDirection * sidewaysInput * sidewaysSpeed;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            rb.AddForce(moveSideways);
        }

        // Move vertically
        float verticalInput = 0f;
        if (Input.GetKey(KeyCode.Space))
        {
            verticalInput += 1f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            verticalInput -= 1f;
        }
        Vector3 verticalDirection = transform.up;
        Vector3 moveVertical = verticalDirection * verticalInput * verticalSpeed;
        rb.AddForce(moveVertical);

        // Mouse view
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * rotationSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.M))
        {
            invertMouse = !invertMouse;
        }

        if (invertMouse)
        {
            transform.Rotate(Vector3.left, -mouseY * rotationSpeed * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Rotate(Vector3.left, mouseY * rotationSpeed * Time.deltaTime, Space.Self);
        }

        // Rotate Z axis
        float rotateInput = Input.GetAxis("Rotate");
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
        }
    }
}
