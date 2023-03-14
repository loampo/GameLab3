using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserWeapon : Weapon
{
    public Transform gunEnd;
    public Transform gunEnd1;

    


    void Update()
    {
        if (Input.GetKey(keyCode) && readyToShoot && PlayerInventory.instance.ammoFirstWeapon > 0)
        {
            Shooting();
            CountAmmo();


        }

    }



    protected override void Shooting()
    {
        base.Shooting();
        GameObject bullet = Instantiate(bulletPrefabs, gunEnd.position, transform.rotation);
        GameObject bullet1 = Instantiate(bulletPrefabs, gunEnd1.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * speedX;
        bullet1.GetComponent<Rigidbody>().velocity = transform.forward * speedX;
        Invoke("ResetShooting", fireRate);
        
    }

    protected override void CountAmmo()
    {
        PlayerInventory.instance.ammoFirstWeapon -= ammoCost;
    }




}

