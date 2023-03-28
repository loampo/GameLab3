using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public Transform player; // riferimento al protagonista
    public float cameraDistance = 10.0f; // distanza della telecamera dal protagonista
    public float cameraSpeed = 1.0f; // velocità di rotazione della telecamera

    private float currentHorizontalAngle = 0.0f; // angolo attuale della telecamera attorno al protagonista
    private float currentVerticalAngle = 0.0f; // angolo verticale attuale della telecamera rispetto al protagonista

    void Update()
    {
        // ruota la telecamera in senso orario se premuta la freccia destra
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentHorizontalAngle -= cameraSpeed * Time.deltaTime;
        }
        // ruota la telecamera in senso antiorario se premuta la freccia sinistra
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentHorizontalAngle += cameraSpeed * Time.deltaTime;
        }

        // aumenta l'angolo verticale della telecamera se premuto il tasto su
        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentVerticalAngle += cameraSpeed * Time.deltaTime;
        }
        // diminuisce l'angolo verticale della telecamera se premuto il tasto giù
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentVerticalAngle -= cameraSpeed * Time.deltaTime;
        }

        // calcola la nuova posizione della telecamera in base all'angolo e all'angolo verticale attuali
        Vector3 cameraPosition = new Vector3(Mathf.Sin(currentHorizontalAngle) * Mathf.Cos(currentVerticalAngle) * cameraDistance, Mathf.Sin(currentVerticalAngle) * cameraDistance, Mathf.Cos(currentHorizontalAngle) * Mathf.Cos(currentVerticalAngle) * cameraDistance);

        // applica la nuova posizione della telecamera
        transform.position = player.position + cameraPosition;
        transform.LookAt(player.position);
    }
}
