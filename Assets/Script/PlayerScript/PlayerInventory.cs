using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    //------------------------------------------------------------Controll Weapon To Equip
    bool m_LaserWeapon; //controll for the weapon to equip
    bool m_Vulcan; //controll for the weapon to equip

    public Transform m_gunEndPrimaryHand; //where i can equip my primary Weapon
    public Transform m_gunEndSecondaryHand; //where i can equip my secondary Weapon
    public List<GameObject> m_weapons = new List<GameObject>(); // all my qeapon 

    private WeaponType m_WeaponEquipable;
    private WeaponType m_LastEquipedWeapon;
    

    private void Awake()
    {
        m_LaserWeapon = true;
        Instantiate(m_weapons[0],m_gunEndPrimaryHand);     //Instantiate the laser weapon to the start
        Instantiate(m_weapons[2], m_gunEndSecondaryHand); //Instantiate the missle weapon to the start 
    }

    private void Update()
    {
       
        SwitchWeapon();

    }

    private void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)&&m_LaserWeapon) // press 1 
        {
            if (m_WeaponEquipable != WeaponType.laserWeapon) m_WeaponEquipable = WeaponType.laserWeapon; //control for the weapon to equip for the primary weapon 
            PlayerInformation.m_instance.SwitchAmmoFromVulcanToLaser(); // switch canvas for the ammo
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)&&m_Vulcan)// press 2 
        {
            if (m_WeaponEquipable != WeaponType.vulcan) m_WeaponEquipable = WeaponType.vulcan; //control for the weapon to equip for the primary weapon 
            PlayerInformation.m_instance.SwitchAmmoFromLaserToVulcan();// switch canvas for the ammo
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))// press 3 
        {
            if (m_WeaponEquipable != WeaponType.missleWeapon) m_WeaponEquipable = WeaponType.missleWeapon; //control for the weapon to equip for the secondary weapon 
            PlayerInformation.m_instance.SwitchAmmoFromHomingMissleToMissle();// switch canvas for the ammo
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))// press 4 
        {
            if (m_WeaponEquipable != WeaponType.homingMissileWeapon) m_WeaponEquipable = WeaponType.homingMissileWeapon; //control for the weapon to equip for the secondary weapon 
            PlayerInformation.m_instance.SwitchAmmoFromMissleToHomingMissle();// switch canvas for the ammo

        }

        if (m_WeaponEquipable != m_LastEquipedWeapon) EquipWeapon(m_WeaponEquipable);

    }

    private void EquipWeapon(WeaponType weaponToEquip) // weapon can i equip
    {
        if ((int)weaponToEquip < 2) //primary weapon
        {
            Destroy(m_gunEndPrimaryHand.GetComponentInChildren<Weapon>().gameObject); //destroy current weapon 
            Instantiate(m_weapons[(int)weaponToEquip], m_gunEndPrimaryHand.transform); // Instantiate the weapon next to it
        }
        else
        {
            Destroy(m_gunEndSecondaryHand.GetComponentInChildren<Weapon>().gameObject); //destroy current weapon 
            Instantiate(m_weapons[(int)weaponToEquip], m_gunEndSecondaryHand.transform); // Instantiate the weapon next to it
        }
        m_LastEquipedWeapon = weaponToEquip;
    }



    public enum WeaponType
    {
        laserWeapon,
        vulcan,
        missleWeapon,
        homingMissileWeapon,
    }



    public void OnTriggerEnter(Collider collider)
    {
        CollisionDetection(collider);
    }

    protected virtual void CollisionDetection(Collider collider)
    {
        if (collider.gameObject.CompareTag(Constants.VULCAN))//if i collider with something with that tag for the Vulcan Weapon
        {
            Destroy(collider.gameObject); //destroy
            m_Vulcan = true; //i can use the Vulcan
            PlayerInformation.m_instance.m_ammoVulcan += PlayerInformation.m_instance.m_restoreAmmoVulcan;
        }
       

    }


}
