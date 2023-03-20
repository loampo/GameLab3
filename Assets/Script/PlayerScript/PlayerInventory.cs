using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    bool laserWeapon;
    bool oneLaserWeapon;
    
    

    
    public Transform gunEndPrimaryHand;
    public Transform gunEndSecondaryHand;
    public List<GameObject> Weapons = new List<GameObject>();


    private WeaponType m_weaponEquipable;
    private WeaponType m_lastEquipedWeapon;
    


    

   

    private void Awake()
    {
        laserWeapon = true;
        Instantiate(Weapons[0],gunEndPrimaryHand);     
        Instantiate(Weapons[2], gunEndSecondaryHand);
    }

    private void Update()
    {
       
        SwitchWeapon();

    }

    private void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)&&laserWeapon)
        {
            if (m_weaponEquipable != WeaponType.laserWeapon) m_weaponEquipable = WeaponType.laserWeapon;
            PlayerInformation.instance.SwitchAmmoFromVulcanToLaser();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)&&oneLaserWeapon)
        {
            if (m_weaponEquipable != WeaponType.oneLaserWeapon) m_weaponEquipable = WeaponType.oneLaserWeapon;
            PlayerInformation.instance.SwitchAmmoFromLaserToVulcan();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (m_weaponEquipable != WeaponType.missleWeapon) m_weaponEquipable = WeaponType.missleWeapon;
            PlayerInformation.instance.SwitchAmmoFromHomingMissleToMissle();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (m_weaponEquipable != WeaponType.HomingMissileWeapon) m_weaponEquipable = WeaponType.HomingMissileWeapon;
            PlayerInformation.instance.SwitchAmmoFromMissleToHomingMissle();

        }

        if (m_weaponEquipable != m_lastEquipedWeapon) EquipWeapon(m_weaponEquipable);

    }

    private void EquipWeapon(WeaponType weaponToEquip)
    {
        if ((int)weaponToEquip < 2)
        {
            Destroy(gunEndPrimaryHand.GetComponentInChildren<Weapon>().gameObject);
            Instantiate(Weapons[(int)weaponToEquip], gunEndPrimaryHand.transform);
        }
        else
        {
            Destroy(gunEndSecondaryHand.GetComponentInChildren<Weapon>().gameObject);
            Instantiate(Weapons[(int)weaponToEquip], gunEndSecondaryHand.transform);
        }
        m_lastEquipedWeapon = weaponToEquip;
    }



    public enum WeaponType
    {
        laserWeapon,
        oneLaserWeapon,
        missleWeapon,
        HomingMissileWeapon,
    }



    public void OnTriggerEnter(Collider collider)
    {
        CollisionDetection(collider);
    }

    protected virtual void CollisionDetection(Collider collider)
    {
        if (collider.gameObject.CompareTag(Constants.ONELW))
        {
            Destroy(collider.gameObject);
            oneLaserWeapon = true;
        }
       

    }


}
