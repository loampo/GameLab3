using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate=0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Transform gunEnd;

    private Camera fpsCam;
    private float nextFire;
    public GameObject bulletPrefabs;

    public Transform hold;

    // Start is called before the first frame update
    void Start()
    {

        fpsCam = GetComponentInChildren<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation,hold);
            
           RaycastHit hit;

           if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
           {
                ShootableBox health = hit.collider.GetComponent<ShootableBox>();
                if (health != null && bullet.GetComponent<SphereCollider>().gameObject.tag=="Enemy")
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage(gunDamage);
                }
            }
        }
    }
         
}

