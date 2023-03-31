using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{


    public float m_fireRate; // fire rate for the enemy
    private bool m_ReadyToShoot; // ready to shoot controll
    public GameObject m_bulletPrefabs; // enemy bullet prefabs
    public float m_speedX; // spped for the bullet 
    public Transform m_gunEndWeapon; // gun end 

    public GameObject m_weapon; // enemy weapon 
    public Transform m_gunEndPrimaryHandEnemy; // gun end primary weapon 


    private void Awake()
    {
        m_ReadyToShoot = true;
    }

    private void Start()
    {
        Instantiate(m_weapon, m_gunEndPrimaryHandEnemy); //Instantiate Enemy Weapon
    }

   
    //shooting system for the enemy 
    public virtual void ShootingBase() 
    {
        if (m_ReadyToShoot) //first controll 
        {
            m_ReadyToShoot = false;
            GameObject bullet = Instantiate(m_bulletPrefabs, m_gunEndWeapon.position, transform.rotation); //Instantiate bullet
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * m_speedX; //bullet velocity 
            Invoke("ResetShooting", m_fireRate); //reset shooting with fireRate
            
        }
    }

    
    //resetShooting
    protected virtual void ResetShooting()
    {
        m_ReadyToShoot = true;
    }



}
