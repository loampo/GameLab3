using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInformation : MonoBehaviour
{


    [Range(1f, 100f)]
    public int m_healt;
    [Range(1f, 200f)]
    public int m_maxHealt;
    [Range(1f, 100f)]
    public int m_ammoLaser;
    [Range(1f, 200f)]
    public int m_maxAmmoLaser;
    [Range(1f, 9999f)]
    public int m_ammoVulcan;
    [Range(1f, 9999f)]
    public int m_maxAmmoVulcan;
    [Range(1f, 20f)]
    public int m_ammoMissle;
    [Range(1f, 20f)]
    public int m_maxAmmoMissle;
    [Range(1f, 20f)]
    public int m_ammoHomingMissle;
    [Range(1f, 20f)]
    public int m_maxAmmoHomingMissle;


    //----------------------------------------------------------Collectible Attributs
    [Range(1f, 20f)]
    public int m_restoreHP;
    [Range(1f, 20f)]
    public int m_restoreAmmoLaser;
    [Range(1f, 20f)]
    public int m_restoreAmmoVulcan;
    [Range(1f, 20f)]
    public int m_restoreAmmoMissle;
    [Range(1f, 20f)]
    public int m_restoreAmmoHomingMissle;
    bool m_AmmoLaserCollectible;
    bool m_AmmoMissleCollectible;


    //----------------------------------------------------------Text for the ammo
    [SerializeField] private TextMeshProUGUI m_AmmoCountLaser;
    [SerializeField] private TextMeshProUGUI m_AmmoCounVulcan;
    [SerializeField] private TextMeshProUGUI m_AmmoCountMissle;
    [SerializeField] private TextMeshProUGUI m_AmmoCountHomingMissle;
    [SerializeField] private TextMeshProUGUI m_HealtCount;

    //----------------------------------------------------------Canvas GameObject for activated Functions
    public GameObject AmmoLaserActivate;
    public GameObject AmmoVulcanActivate;
    public GameObject AmmoMissleActivate;
    public GameObject AmmoHomingMissleActivate;


    public static PlayerInformation instance;


    private void Awake()
    {
        m_AmmoLaserCollectible = true;
        AmmoLaserActivate.SetActive(true);
        m_AmmoMissleCollectible = true;
        AmmoMissleActivate.SetActive(true);
        AmmoHomingMissleActivate.SetActive(false);
        AmmoVulcanActivate.SetActive(false);
        //Controllo in più
        if (instance == null)
            instance = this;
        
    }
    private void Update()
    {

        m_AmmoCountLaser.text = m_ammoLaser.ToString();
        m_AmmoCountMissle.text = m_ammoMissle.ToString();
        m_AmmoCountHomingMissle.text = m_ammoHomingMissle.ToString();
        m_AmmoCounVulcan.text = m_ammoVulcan.ToString();
        m_HealtCount.text = m_healt.ToString();
        

    }

    public void OnTriggerEnter(Collider collider)
    {
        CollisionDetection(collider);
    }

    protected virtual void CollisionDetection(Collider collider)
    {
        if (collider.gameObject.CompareTag(Constants.AMMOFW))
        {
            if (m_AmmoLaserCollectible)
            {
                if (m_ammoLaser >= m_maxAmmoLaser)
                {
                    Destroy(collider.gameObject);
                }
                else
                {
                    Destroy(collider.gameObject);
                    m_ammoLaser += m_restoreAmmoLaser;
                }
            }
            else if (!m_AmmoLaserCollectible)
            {
                if (m_ammoVulcan >= m_maxAmmoVulcan)
                {
                    Destroy(collider.gameObject);
                }
                else
                {
                    Destroy(collider.gameObject);
                    m_ammoVulcan += m_restoreAmmoVulcan;
                }
            }

        }
        if (collider.gameObject.CompareTag(Constants.AMMOSW))
        {
            if (m_AmmoMissleCollectible)
            {
                if (m_ammoMissle >= m_maxAmmoMissle)
                {
                    Destroy(collider.gameObject);
                }
                else
                {
                    Destroy(collider.gameObject);
                    m_ammoMissle += m_restoreAmmoMissle;
                }
            }
            else if (!m_AmmoMissleCollectible)
            {
                if (m_ammoHomingMissle >= m_maxAmmoHomingMissle)
                {
                    Destroy(collider.gameObject);
                }
                else
                {
                    Destroy(collider.gameObject);
                    m_ammoHomingMissle += m_restoreAmmoHomingMissle;
                }
            }
            
            

        }


        if (collider.gameObject.CompareTag(Constants.SHIELD))
        {
            if (m_healt >= m_maxHealt) Destroy(collider.gameObject);
            else
            {
                Destroy(collider.gameObject);
                m_healt += m_restoreHP;
            }
            

        }
        if (collider.gameObject.CompareTag(Constants.ASTRONAUT))
        {
            Destroy(collider.gameObject);
            GameManager.instance.score += GameManager.instance.astronautScorePoints;

        }


    }

    public void SwitchAmmoFromLaserToVulcan()
    {
        AmmoLaserActivate.SetActive(false);
        AmmoVulcanActivate.SetActive(true);
        m_AmmoLaserCollectible = false;
    }

    public void SwitchAmmoFromVulcanToLaser()
    {
        AmmoLaserActivate.SetActive(true);
        AmmoVulcanActivate.SetActive(false);
        m_AmmoLaserCollectible = true;
    }

    public void SwitchAmmoFromMissleToHomingMissle()
    {
        AmmoMissleActivate.SetActive(false);
        AmmoHomingMissleActivate.SetActive(true);
        m_AmmoMissleCollectible = false;
    }

    public void SwitchAmmoFromHomingMissleToMissle()
    {
        AmmoMissleActivate.SetActive(true);
        AmmoHomingMissleActivate.SetActive(false);
        m_AmmoMissleCollectible = true;
    }


    public void Damage(int damageAmount)
    {
        m_healt -= damageAmount;

        //Check if health has fallen below zero
        if (m_healt <= 0)
        {
            Destroy(gameObject);

        }

    }


}
