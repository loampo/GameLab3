using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneLaserWeapon : Weapon
{
    public Transform gunEnd;


    void Update()
    {
        if (Input.GetKey(keyCode) && readyToShoot && PlayerInformation.instance.m_ammoLaser > 0)
        {
            Shooting();
            CountAmmo();


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
        PlayerInformation.instance.m_ammoVulcan -= ammoCost;
    }


}
