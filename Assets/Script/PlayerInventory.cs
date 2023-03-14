using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI AmmoCountFirstWeapon;
    [SerializeField] private TextMeshProUGUI AmmoCountSecondWeapon;

    [Range(1f, 100f)]
    public int ammoFirstWeapon;
    [Range(1f, 20f)]
    public int ammoSecondWeapon;
    public Transform gunEndPrimaryHand;
    public Transform gunEndSecondaryHand;
    public List<GameObject> Weapons = new List<GameObject>();


    private WeaponType m_weaponToEquip;
    private WeaponType m_lastEquipedWeapon;
    


    public static PlayerInventory instance;

   

    private void Awake()
    {
        Instantiate(Weapons[0],gunEndPrimaryHand);
        //Controllo in più
        if (instance == null)
            instance = this;
        Instantiate(Weapons[2], gunEndSecondaryHand);
    }

    private void Update()
    {
        AmmoCountFirstWeapon.text =ammoFirstWeapon.ToString();
        AmmoCountSecondWeapon.text = ammoSecondWeapon.ToString();
        SwitchWeapon();

    }

    private void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (m_weaponToEquip != WeaponType.laserWeapon) m_weaponToEquip = WeaponType.laserWeapon;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (m_weaponToEquip != WeaponType.oneLaserWeapon) m_weaponToEquip = WeaponType.oneLaserWeapon;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (m_weaponToEquip != WeaponType.missleWeapon) m_weaponToEquip = WeaponType.missleWeapon;

        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (m_weaponToEquip != WeaponType.HomingMissileWeapon) m_weaponToEquip = WeaponType.HomingMissileWeapon;

        }

        if (m_weaponToEquip != m_lastEquipedWeapon) EquipWeapon(m_weaponToEquip);

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



}
