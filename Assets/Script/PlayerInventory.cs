using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI AmmoCountFirstWeapon;
    [SerializeField] private TextMeshProUGUI AmmoCountSecondWeapon;
    public int ammoFirstWeapon = 100;
    public int ammoSecondWeapon = 100;
    public GameObject firstWeapon;
    public GameObject secondWeapon;
    public Transform gunEnd;
    public List<GameObject> Weapons = new List<GameObject>();

    public static PlayerInventory instance;

   

    private void Awake()
    {
        Instantiate(firstWeapon,gunEnd);
        //Controllo in più
        if (instance == null)
            instance = this;
        Instantiate(secondWeapon, gunEnd);
    }

    private void Update()
    {
        AmmoCountFirstWeapon.text =ammoFirstWeapon.ToString();
        AmmoCountSecondWeapon.text = ammoSecondWeapon.ToString();

    }

    



}
