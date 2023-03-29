using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 10.0f; // distanza della telecamera dal protagonista
    public float cameraSpeed = 1.0f; // velocità di rotazione della telecamera

    private float currentHorizontalAngle = 0.0f; 
    private float currentVerticalAngle = 0.0f; 

    void Update()
    {
        // ruota la telecamera in senso orario
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentHorizontalAngle -= cameraSpeed * Time.deltaTime;
        }
        // ruota la telecamera in senso antiorario
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentHorizontalAngle += cameraSpeed * Time.deltaTime;
        }

        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentVerticalAngle += cameraSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentVerticalAngle -= cameraSpeed * Time.deltaTime;
        }

        // calcola la nuova posizione della telecamera
        Vector3 cameraPosition = new Vector3(Mathf.Sin(currentHorizontalAngle) * Mathf.Cos(currentVerticalAngle) * cameraDistance, Mathf.Sin(currentVerticalAngle) * cameraDistance, Mathf.Cos(currentHorizontalAngle) * Mathf.Cos(currentVerticalAngle) * cameraDistance);

        // applica la nuova posizione della telecamera
        transform.position = player.position + cameraPosition;
        transform.LookAt(player.position);
    }
}
