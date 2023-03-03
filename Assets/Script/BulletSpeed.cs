using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    float speedX = 10f;


    public void Update()
    {
        transform.position += transform.forward * speedX * Time.deltaTime;
    }

}
