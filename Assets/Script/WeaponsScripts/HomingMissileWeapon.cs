using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileWeapon : Weapon
{

    
    
    


    void Update()
    {
        if (Input.GetKey(m_keyCode) && m_ReadyToShoot && PlayerInformation.m_instance.m_ammoHomingMissle > 0)
        {

            Shooting();
            CountAmmo();

        }

    }


    protected override void Shooting()
    {
        base.Shooting();
        GameObject bullet = Instantiate(m_bulletPrefabs, m_gunEnd.position,transform.rotation); //Instantiate bullet
        Invoke("ResetShooting", m_fireRate); //reset shooting with fireRate

    }


    //count ammo
    protected override void CountAmmo()
    {
        PlayerInformation.m_instance.m_ammoHomingMissle -= m_ammoCost; //count ammo
    }

}
