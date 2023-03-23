using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public float m_fireRate; //fire rate for the player 
    protected bool m_ReadyToShoot; //if i can shoot again 
    protected float m_NextFire; //next bullet 
    public int m_ammoCost; // cost for every bullet 
    public GameObject m_bulletPrefabs; //bullet prefabs that will be used for the weapon 
    public float m_speedX; //bullet speed 
    public KeyCode m_keyCode; //which key you can shoot with




    private void Awake()
    {
        m_ReadyToShoot = true;
    }


    protected virtual void Shooting() //shooting system 
    {
        m_ReadyToShoot = false;
        
    }

    protected virtual void ResetShooting() //if i can shoot again
    {
        m_ReadyToShoot = true;
    }

    protected abstract void CountAmmo(); //caunt ammo for the player
    


}



