using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileWeapon : Weapon
{

    
    public Transform gunEnd;


    void Update()
    {
        if (Input.GetKey(keyCode) && readyToShoot && PlayerInformation.instance.ammoSecondWeapon > 0)
        {

            Shooting();
            CountAmmo();

        }

    }


    protected override void Shooting()
    {
        base.Shooting();
        GameObject bullet = Instantiate(bulletPrefabs, gunEnd.position,transform.rotation);
        Invoke("ResetShooting", fireRate);

    }



    protected override void CountAmmo()
    {
        PlayerInformation.instance.ammoSecondWeapon -= ammoCost;
    }

}
