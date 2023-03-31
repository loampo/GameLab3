using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    //----------------------------------------------------------Text for the ammo
    public TextMeshProUGUI m_ammoCountLaser; //text for the Laser ammo count
    public TextMeshProUGUI m_ammoCounVulcan; //text for the Vulcan ammo count
    public TextMeshProUGUI m_ammoCountMissle; //text for the Missle ammo count
    public TextMeshProUGUI m_ammoCountHomingMissle; //text for the Homing missle ammo count
    public TextMeshProUGUI m_energyCount; //text for the energy
    public TextMeshProUGUI m_healtCount; //text for the Healt count
    public Image[] m_shieldImages; //Shield images
    public Image[] m_EnergyImagesR; //Energy images R
    public Image[] m_EnergyImagesL; //Energy images L
    public Image[] m_lives;
    

    //----------------------------------------------------------Canvas GameObject for activated Functions
    [SerializeField] private GameObject m_AmmoLaserActivate; //switch ammo count 
    [SerializeField] private GameObject m_AmmoVulcanActivate; //switch ammo count 
    [SerializeField] private GameObject m_AmmoMissleActivate; //switch ammo count 
    [SerializeField] private GameObject m_AmmoHomingMissleActivate; //switch ammo count 
    public GameObject m_redKeyImage;

    //----------------------------------------------------------Canvas Scene
    public GameObject m_lockImage;
    public GameObject m_pause;
    public GameObject m_loseScene;  
    public GameObject m_loseScene0Live;
    public GameObject m_winScene;

    

    [SerializeField] private Canvas canvas;


    public static UIManager m_instance;

    private void Awake()
    {

        m_AmmoLaserActivate.SetActive(true);
        m_AmmoMissleActivate.SetActive(true);
        m_AmmoHomingMissleActivate.SetActive(false);
        m_AmmoVulcanActivate.SetActive(false);
        //Controllo in più
        if (m_instance == null)
            m_instance = this;
        m_lockImage.SetActive(false);
    }

   

    public void SwitchAmmoFromLaserToVulcan()
    {
        m_AmmoLaserActivate.SetActive(false);
        m_AmmoVulcanActivate.SetActive(true);
        
    }


    public void SwitchAmmoFromVulcanToLaser()
    {
        m_AmmoLaserActivate.SetActive(true);
        m_AmmoVulcanActivate.SetActive(false);
        
    }

    public void SwitchAmmoFromMissleToHomingMissle()
    {
        m_AmmoMissleActivate.SetActive(false);
        m_AmmoHomingMissleActivate.SetActive(true);
        
    }

    public void SwitchAmmoFromHomingMissleToMissle()
    {
        m_AmmoMissleActivate.SetActive(true);
        m_AmmoHomingMissleActivate.SetActive(false);
        
    }

    public void SwitchFromMainCameraToBack()
    {

        canvas.enabled = false;
    }

    public void SwitchFromBackCameraToMainCamera()
    {

        canvas.enabled = true;
    }

 
}
