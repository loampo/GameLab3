using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneLaserWeapon : Weapon
{
    public Transform m_gunEnd; //gun end 


    void Update()
    {
        if (Input.GetKey(m_keyCode) && m_ReadyToShoot && PlayerInformation.m_instance.m_ammoLaser > 0) //press the key 
        {
            Shooting();
            CountAmmo();


        }

    }



    protected override void Shooting()
    {
        base.Shooting();
        GameObject bullet = Instantiate(m_bulletPrefabs, m_gunEnd.position, transform.rotation); //Instantiate bullet
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * m_speedX; //bullet velocity 
        Invoke("ResetShooting", m_fireRate); //reset shooting with fireRate

    }

    //count ammo 
    protected override void CountAmmo()
    {
        PlayerInformation.m_instance.m_ammoVulcan -= m_ammoCost; //count ammo 
    }


}
