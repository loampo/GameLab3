using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public float fireRate;
    protected bool readyToShoot;
    protected float nextFire;
    public GameObject bulletPrefabs;
    public float speedX;
    public Transform gunEndWeapon;

    public GameObject weapon;
    public Transform gunEndPrimaryHandEnemy;


    private void Awake()
    {
        readyToShoot = true;
    }

    private void Start()
    {
        Instantiate(weapon, gunEndPrimaryHandEnemy);
    }

   

    public virtual void Shooting()
    {
        if (readyToShoot)
        {
            readyToShoot = false;
            GameObject bullet = Instantiate(bulletPrefabs, gunEndWeapon.position, transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * speedX;
            Invoke("ResetShooting", fireRate);

        }
    }


    protected virtual void ResetShooting()
    {
        readyToShoot = true;
    }



}
