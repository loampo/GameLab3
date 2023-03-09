using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Vector2 sensitivity;
    public Vector2 accelleration;
    public float inputLagPeriod;
    private Vector2 rotation;
    private Vector2 velocity;
    private Vector2 lastInputEvent;
    private float inputLagTimer;

    private Vector2 GetInput()
    {
        inputLagTimer += Time.deltaTime;
        Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        

        if ((Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y)) == false || inputLagTimer >= inputLagPeriod)
        {
            lastInputEvent = input;
            inputLagTimer = 0;
        }
        return lastInputEvent;
    }


    private void Update()
    {
        Vector2 wantedVelocity = GetInput() * sensitivity;

        velocity = new Vector2(
            Mathf.MoveTowards(velocity.x, wantedVelocity.x, accelleration.x * Time.deltaTime),
            Mathf.MoveTowards(velocity.y, wantedVelocity.y, accelleration.y * Time.deltaTime));

        rotation += velocity * Time.deltaTime;

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }



}
