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
