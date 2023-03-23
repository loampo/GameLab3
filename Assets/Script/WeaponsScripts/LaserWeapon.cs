using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserWeapon : Weapon
{
    public Transform m_gunEnd;
    public Transform m_gunEnd1;

    


    void Update()
    {
        if (Input.GetKey(m_keyCode) && m_ReadyToShoot && PlayerInformation.m_instance.m_ammoLaser > 0) //press key
        {
            Shooting();
            CountAmmo();


        }

    }



    protected override void Shooting()
    {
        base.Shooting();
        GameObject bullet = Instantiate(m_bulletPrefabs, m_gunEnd.position, transform.rotation); //Instantiate bullet
        GameObject bullet1 = Instantiate(m_bulletPrefabs, m_gunEnd1.position, transform.rotation); //Instantiate bullet
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * m_speedX; //bullet velocity 
        bullet1.GetComponent<Rigidbody>().velocity = transform.forward * m_speedX; //bullet velocity 
        Invoke("ResetShooting", m_fireRate); //reset shooting with fireRate

    }

    //count ammo 
    protected override void CountAmmo()
    {
        PlayerInformation.m_instance.m_ammoLaser -= m_ammoCost; //count ammo 
    }




}

