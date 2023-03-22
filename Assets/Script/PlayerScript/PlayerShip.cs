using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    private CursorLockMode cursorLockMode = CursorLockMode.Locked;
    private bool cursorVisible = false;
    public float forwardSpeed = 100f;
    public float sidewaysSpeed = 100f;
    public float rotationSpeed = 100f;
    public float verticalSpeed = 100f;
    public float maxSpeed = 200f;

    private Rigidbody rb;
    private bool invertMouse = false;
    private void Awake()
    {
        //Da spostare nella UI in futuro
        Cursor.lockState = cursorLockMode; //Impedisce al cursore di uscire dallo schermo
        Cursor.visible = cursorVisible; // Nasconde il cursore del mouse
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
       
    }

    void Update()
    {
        //Max Speed
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        // Move forward/backward
        float forwardInput = Input.GetAxis("Vertical");
        float sidewaysInput = Input.GetAxis("Horizontal");
        Vector3 forwardDirection = transform.forward;
        Vector3 moveDirection = forwardDirection * forwardInput * forwardSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            rb.AddForce(moveDirection);
        }

        // Move sideways
        Vector3 sidewaysDirection = transform.right;
        Vector3 moveSideways = sidewaysDirection * sidewaysInput * sidewaysSpeed * Time.deltaTime;
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
        Vector3 moveVertical = verticalDirection * verticalInput * verticalSpeed * Time.deltaTime;
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
