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
    [HideInInspector]
    public int m_ammoLaser; //ammo for Laser 
    [Range(1f, 200f)]
    public int m_maxAmmoLaser; //maxAmmo for Laser 
    [Range(0f, 9999f)]
    public int m_ammoVulcan; //ammo for Vulcan
    [Range(1f, 9999f)]
    public int m_maxAmmoVulcan; //maxAmmo for Vulcan
    [Range(1f, 200f)]
    public float m_energy; //energy 
    [Range(1f, 400f)]
    public int m_Maxenergy; //energy 
    [Range(1f, 20f)]
    public int m_ammoMissle; //ammo for Missle
    [Range(1f, 20f)]
    public int m_maxAmmoMissle; //maxAmmo for Missle
    [Range(0f, 20f)]
    public int m_ammoHomingMissle; //ammo for Homing missle
    [Range(1f, 20f)]
    public int m_maxAmmoHomingMissle; //maxAmmo for Homing missle


    //----------------------------------------------------------Collectible Attributs
    [Range(1f, 20f)]
    public int m_restoreHP; //how much hp can restore 
    [Range(1f, 20f)]
    public int m_restoreEnergy; //how much energy can restore
    [Range(1f, 1250f)]
    public int m_restoreAmmoVulcan; //how much Vulcan ammo can restore 
    [Range(1f, 20f)]
    public int m_restoreAmmoMissle; //how much Missle ammo can restore 
    [Range(1f, 20f)]
    public int m_restoreAmmoHomingMissle; //how much Homing missle ammo can restore 
    [HideInInspector] public bool m_ammoLaserCollectible; //to figure out which ammunition to restock
    [HideInInspector] public bool m_ammoMissleCollectible =true; //to figure out which amminition to restock
    
    bool m_RedKey; // red key to open the last gate 
    [HideInInspector]
    public bool is_EnergyPickUp;




    //----------------------------------------------------------Singleton
    public static PlayerInformation m_instance;

    //set Canvas with right information about ammo and about the right weapon equiped on start
    private void Awake()
    {

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
        int EnergyINT = Mathf.RoundToInt(m_energy);
        UIManager.m_instance.m_energyCount.text = EnergyINT.ToString();



    }


    public void OnTriggerEnter(Collider collider)
    {
        CollisionDetection(collider);
    }

    protected virtual void CollisionDetection(Collider collider)
    {
        if (collider.gameObject.CompareTag(Constants.AMMOFW)) //if i collider with something with that tag for the ammo
        {
            if (!m_ammoLaserCollectible) //if the weapon that i equiped isn't m_AmmoLaserCollectible it means is vulcan weapon 
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
        if (collider.gameObject.CompareTag(Constants.AMMOMW))
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
        if (collider.gameObject.CompareTag(Constants.AMMOHMW))
        {

            if (m_ammoHomingMissle >= m_maxAmmoHomingMissle)  //if i have more ammo that i can have 
            {
                Destroy(collider.gameObject); //destroy
            }
            else
            {
                Destroy(collider.gameObject); //destroy
                m_ammoHomingMissle += m_restoreAmmoHomingMissle; //restore ammo
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
            GameManager.instance.m_score += GameManager.instance.m_astronautScorePoints; // add points to the GameManager 

        }
        if (collider.gameObject.CompareTag(Constants.REDKEY))  //if i collider with something with that tag REDKEY
        {
            Destroy(collider.gameObject); //destroy
            m_RedKey = true; 

        }
        if (collider.gameObject.CompareTag(Constants.ENERGY))
        {
            is_EnergyPickUp = true;
            if (m_energy >= m_Maxenergy)  //if i have more ammo that i can have 
            {
                Destroy(collider.gameObject); //destroy
                
            }
            else
            {
                Destroy(collider.gameObject); //destroy
                m_energy += m_restoreEnergy; //restore ammo
                
            }
        }
        
    }

    //i use this funcion for Switching the Canvas information about ammo 
    public void SwitchAmmoFromLaserToVulcan()
    {
        m_ammoLaserCollectible = false;
        UIManager.m_instance.SwitchAmmoFromLaserToVulcan();
        
    }

    //i use this funcion for Switching the Canvas information about ammo 
    public void SwitchAmmoFromVulcanToLaser()
    {
        m_ammoLaserCollectible = true;
        UIManager.m_instance.SwitchAmmoFromVulcanToLaser();
    }

    //i use this funcion for Switching the Canvas information about ammo 
    public void SwitchAmmoFromMissleToHomingMissle()
    {
        m_ammoMissleCollectible = false;
        UIManager.m_instance.SwitchAmmoFromMissleToHomingMissle();
    }

    //i use this funcion for Switching the Canvas information about ammo 
    public void SwitchAmmoFromHomingMissleToMissle()
    {
        m_ammoMissleCollectible = true;
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
