using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInventory : MonoBehaviour
{
    bool laserWeapon;
    bool oneLaserWeapon;
    bool missleWeapon;
    bool homingMissleWeapon;

    
    public Transform gunEndPrimaryHand;
    public Transform gunEndSecondaryHand;
    public List<GameObject> Weapons = new List<GameObject>();


    private WeaponType m_weaponEquipable;
    private WeaponType m_lastEquipedWeapon;
    


    

   

    private void Awake()
    {
        laserWeapon = true;
        missleWeapon = true;
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

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)&&oneLaserWeapon)
        {
            if (m_weaponEquipable != WeaponType.oneLaserWeapon) m_weaponEquipable = WeaponType.oneLaserWeapon;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)&&missleWeapon)
        {
            if (m_weaponEquipable != WeaponType.missleWeapon) m_weaponEquipable = WeaponType.missleWeapon;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4)&&homingMissleWeapon)
        {
            if (m_weaponEquipable != WeaponType.HomingMissileWeapon) m_weaponEquipable = WeaponType.HomingMissileWeapon;

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
        if (collider.gameObject.CompareTag(Constants.HOMINGMW))
        {
            Destroy(collider.gameObject);
            homingMissleWeapon = true;
        }

    }


}
