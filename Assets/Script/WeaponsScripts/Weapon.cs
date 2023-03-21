using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public float fireRate;
    protected bool readyToShoot;
    protected float nextFire;
    public int ammoCost;
    public GameObject bulletPrefabs;
    public float speedX;
    public KeyCode keyCode;




    private void Awake()
    {
        readyToShoot = true;
    }


    protected virtual void Shooting()
    {
        readyToShoot = false;
        
    }

    protected virtual void ResetShooting()
    {
        readyToShoot = true;
    }

    protected abstract void CountAmmo();
    


}



