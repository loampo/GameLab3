using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInformation : MonoBehaviour
{
    [Range(1f, 100f)]
    public int healt;
    [Range(1f, 200f)]
    public int maxHealt;

    
    [Range(1f, 100f)]
    public int ammoFirstWeapon;
    [Range(1f, 200f)]
    public int maxAmmoFirstWeapon;
    [Range(1f, 20f)]
    public int ammoSecondWeapon;
    [Range(1f, 20f)]
    public int maxAmmoSecondWeapon;

    [Range(1f, 20f)]
    public int restoreHP;
    [Range(1f, 20f)]
    public int restoreAmmoFirstWeapon;
    [Range(1f, 20f)]
    public int restoreAmmoSecondWeapon;


    [SerializeField] private TextMeshProUGUI AmmoCountFirstWeapon;
    [SerializeField] private TextMeshProUGUI AmmoCountSecondWeapon;
    [SerializeField] private TextMeshProUGUI HealtCount;


    public static PlayerInformation instance;


    private void Awake()
    {
        
        //Controllo in più
        if (instance == null)
            instance = this;
        
    }
    private void Update()
    {
        AmmoCountFirstWeapon.text = ammoFirstWeapon.ToString();
        AmmoCountSecondWeapon.text = ammoSecondWeapon.ToString();
        HealtCount.text = healt.ToString();

    }

    public void OnTriggerEnter(Collider collider)
    {
        CollisionDetection(collider);
    }

    protected virtual void CollisionDetection(Collider collider)
    {
        if (collider.gameObject.CompareTag(Constants.AMMOFW))
        {
            if (ammoFirstWeapon >= maxAmmoFirstWeapon) Destroy(collider.gameObject);
            else
            {
                Destroy(collider.gameObject);
                ammoFirstWeapon += restoreAmmoFirstWeapon;
            }
            

        }
        if (collider.gameObject.CompareTag(Constants.AMMOSW))
        {
            if (ammoSecondWeapon >= maxAmmoSecondWeapon) Destroy(collider.gameObject);
            else
            {
                Destroy(collider.gameObject);
                ammoSecondWeapon += restoreAmmoSecondWeapon;
            }
            

        }
        if (collider.gameObject.CompareTag(Constants.SHIELD))
        {
            if (healt >= maxHealt) Destroy(collider.gameObject);
            else
            {
                Destroy(collider.gameObject);
                healt += restoreHP;
            }
            

        }
        if (collider.gameObject.CompareTag(Constants.ASTRONAUT))
        {
            Destroy(collider.gameObject);
            GameManager.instance.score += GameManager.instance.astronautScorePoints;

        }


    }



}
