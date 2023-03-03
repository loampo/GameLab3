using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{


    public GameObject bulletPrefabs;



    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shooting();
        }
        Debug.DrawRay(transform.position, Vector3.forward * 100, Color.red);
    }
    public void Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
        
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {

                Destroy(hit.collider.gameObject, 10f);
                Destroy(bullet);
            }
        }

    }
}
