using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{

    //----------------------------------------------------------Player Information
    [Range(1f, 100f)]
    public int m_healt;  //helat for the Playe 
    [Range(1f, 200f)] 
    public int m_maxHealt; //maxHealt for the Playe 
    [Range(1f, 100f)]
    public int m_ammoLaser; //ammo for Laser 
    [Range(1f, 200f)]
    public int m_maxAmmoLaser; //maxAmmo for Laser 
    [Range(1f, 9999f)]
    public int m_ammoVulcan; //ammo for Vulcan
    [Range(1f, 9999f)]
    public int m_maxAmmoVulcan; //maxAmmo for Vulcan
    [Range(1f, 20f)]
    public int m_ammoMissle; //ammo for Missle
    [Range(1f, 20f)]
    public int m_maxAmmoMissle; //maxAmmo for Missle
    [Range(1f, 20f)]
    public int m_ammoHomingMissle; //ammo for Homing missle
    [Range(1f, 20f)]
    public int m_maxAmmoHomingMissle; //maxAmmo for Homing missle


    //----------------------------------------------------------Collectible Attributs
    [Range(1f, 20f)]
    public int m_restoreHP; //how much hp can restore 
    [Range(1f, 20f)]
    public int m_restoreAmmoLaser; //how much Laser ammo can restore 
    [Range(1f, 20f)]
    public int m_restoreAmmoVulcan; //how much Vulcan ammo can restore 
    [Range(1f, 20f)]
    public int m_restoreAmmoMissle; //how much Missle ammo can restore 
    [Range(1f, 20f)]
    public int m_restoreAmmoHomingMissle; //how much Homing missle ammo can restore 
    bool m_AmmoLaserCollectible; //to figure out which ammunition to restock
    bool m_AmmoMissleCollectible; //to figure out which ammunition to restock
    bool m_RedKey; // red key to open the last gate 




    //----------------------------------------------------------Singleton
    public static PlayerInformation m_instance;

    //set Canvas with right information about ammo and about the right weapon equiped on start
    private void Awake()
    {
        m_AmmoLaserCollectible = true;
        m_AmmoMissleCollectible = true;

        //Controllo in più
        if (m_instance == null)
            m_instance = this;
        
    }

    //write starting ammo
    private void Update()
    {

        UIManager.m_instance.m_ammoCountLaser.text = m_ammoLaser.ToString();
        UIManager.m_instance.m_ammoCountMissle.text = m_ammoMissle.ToString();
        UIManager.m_instance.m_ammoCountHomingMissle.text = m_ammoHomingMissle.ToString();
        UIManager.m_instance.m_ammoCounVulcan.text = m_ammoVulcan.ToString();
        UIManager.m_instance.m_healtCount.text = m_healt.ToString();
        

    }


    public void OnTriggerEnter(Collider collider)
    {
        CollisionDetection(collider);
    }

    protected virtual void CollisionDetection(Collider collider)
    {
        if (collider.gameObject.CompareTag(Constants.AMMOFW)) //if i collider with something with that tag for the ammo
        {
            if (m_AmmoLaserCollectible) //if the weapon that i equiped is m_AmmoLaserCollectible it means is Laser Weapon
            {
                if (m_ammoLaser >= m_maxAmmoLaser) //if i have more ammo that i can have 
                {
                    Destroy(collider.gameObject); //destroy
                }
                else
                {
                    Destroy(collider.gameObject);  //destroy
                    m_ammoLaser += m_restoreAmmoLaser; //restore ammo
                }
            }
            else if (!m_AmmoLaserCollectible) //if the weapon that i equiped isn't m_AmmoLaserCollectible it means is vulcan weapon 
            {
                if (m_ammoVulcan >= m_maxAmmoVulcan) //if i have more ammo that i can have 
                {
                    Destroy(collider.gameObject); //destroy
                }
                else
                {
                    Destroy(collider.gameObject); //destroy
                    m_ammoVulcan += m_restoreAmmoVulcan; //restore ammo
                }
            }

        }
        if (collider.gameObject.CompareTag(Constants.AMMOSW))
        {
            if (m_AmmoMissleCollectible) //if the weapon that i equiped is m_AmmoMissleCollectible it means is Missle weapon 
            {
                if (m_ammoMissle >= m_maxAmmoMissle)  //if i have more ammo that i can have 
                {
                    Destroy(collider.gameObject); //destroy
                }
                else
                {
                    Destroy(collider.gameObject); //destroy
                    m_ammoMissle += m_restoreAmmoMissle; //restore ammo
                }
            }
            else if (!m_AmmoMissleCollectible) //if the weapon that i equiped isn't m_AmmoMissleCollectible it means is Homing Missle 
            {
                if (m_ammoHomingMissle >= m_maxAmmoHomingMissle) //if i have more ammo that i can have 
                {
                    Destroy(collider.gameObject); //destroy
                }
                else
                {
                    Destroy(collider.gameObject); //destroy
                    m_ammoHomingMissle += m_restoreAmmoHomingMissle; //restore ammo
                }
            }
            
            

        }


        if (collider.gameObject.CompareTag(Constants.SHIELD))
        {
            if (m_healt >= m_maxHealt) Destroy(collider.gameObject);  //if i collider with something with that tag for the SHIELD
            else
            {
                Destroy(collider.gameObject); //destroy
                m_healt += m_restoreHP; //restore Shield
            }
            

        }
        if (collider.gameObject.CompareTag(Constants.ASTRONAUT))  //if i collider with something with that tag for the ASTRONAUT
        {
            Destroy(collider.gameObject); //destroy
            GameManager.instance.score += GameManager.instance.astronautScorePoints; // add points to the GameManager 

        }
        if (collider.gameObject.CompareTag(Constants.REDKEY))  //if i collider with something with that tag REDKEY
        {
            Destroy(collider.gameObject); //destroy
            m_RedKey = true; 

        }

    }

    //i use this funcion for Switching the Canvas information about ammo 
    public void SwitchAmmoFromLaserToVulcan()
    {
        UIManager.m_instance.SwitchAmmoFromLaserToVulcan();
        m_AmmoLaserCollectible = false;
    }

    //i use this funcion for Switching the Canvas information about ammo 
    public void SwitchAmmoFromVulcanToLaser()
    {
        m_AmmoLaserCollectible = true;
        UIManager.m_instance.SwitchAmmoFromVulcanToLaser();
    }

    //i use this funcion for Switching the Canvas information about ammo 
    public void SwitchAmmoFromMissleToHomingMissle()
    {
        m_AmmoMissleCollectible = false;
        UIManager.m_instance.SwitchAmmoFromMissleToHomingMissle();
    }

    //i use this funcion for Switching the Canvas information about ammo 
    public void SwitchAmmoFromHomingMissleToMissle()
    {
        m_AmmoMissleCollectible = true;
        UIManager.m_instance.SwitchAmmoFromHomingMissleToMissle();
    }

    //funcion for taking damage from enemy bullet
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
