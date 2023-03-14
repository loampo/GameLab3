using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileWeapon : Weapon
{

    
    public Transform gunEnd;


    
    
    [Range(1f, 100f)] public float m_MaxDistance;
    [Range(1f, 10f)] public float  m_Speed;
    public Vector3 radius;
    public Vector3 position;
    SphereCollider sphereCollider;
    bool m_HitDetect;
    RaycastHit m_Hit;

    void Update()
    {
        if (Input.GetKey(keyCode) && readyToShoot && PlayerInventory.instance.ammoSecondWeapon > 0)
        {

            Shooting();
            CountAmmo();

        }
        
        //Test to see if there is a hit using a BoxCast
        //Calculate using the center of the GameObject's Collider(could also just use the GameObject's position), half the GameObject's size, the direction, the GameObject's rotation, and the maximum distance as variables.
        //Also fetch the hit data
        m_HitDetect = Physics.BoxCast(transform.position + position, radius, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);
        if (m_HitDetect)
        {

            //Output the name of the Collider your Box hit
            Debug.Log("Hit : " + m_Hit.collider.name);
        }

    }

    //Draw the BoxCast as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + position + transform.forward * m_Hit.distance, radius);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * m_MaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + position + transform.forward * m_MaxDistance, radius);
        }
    }



    protected override void Shooting()
    {
        base.Shooting();
        GameObject bullet = Instantiate(bulletPrefabs, gunEnd.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * speedX;
        Invoke("ResetShooting", fireRate);

    }



    protected override void CountAmmo()
    {
        PlayerInventory.instance.ammoSecondWeapon -= ammoCost;
    }

}
