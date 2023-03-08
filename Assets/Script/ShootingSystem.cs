using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{


    public GameObject m_bulletPrefabs;
    public Transform m_spawn1;
    public Transform m_spawn2;
   


    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shooting() ;

        }
    }
    //private void FixedUpdate()
    //{
    //    if (Input.GetKey(KeyCode.Mouse0))
    //    {
    //        StartCoroutine(ShootingDellay());

    //    }
    //    Debug.DrawRay(transform.position, Vector3.forward * 100, Color.red);
    //}
    //public void Shooting()
    //{
    //    GameObject bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);

    //    RaycastHit hit;

    //    if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
    //    {
    //        if (hit.collider.gameObject.tag == "Enemy")
    //        {

    //            Destroy(hit.collider.gameObject, 3f);
    //            Destroy(bullet);
    //        }
    //    }

    //}


    //IEnumerator ShootingDellay()
    //{
    //    yield return new WaitForSeconds(1f);
    //    Instantiate(m_bulletPrefabs, m_spawn1.position, Quaternion.identity);
    //    Instantiate(m_bulletPrefabs, m_spawn2.position, Quaternion.identity);
        
        
    //}
    private void Shooting()
    {
        Instantiate(m_bulletPrefabs, m_spawn1.position, Quaternion.identity);
        Instantiate(m_bulletPrefabs, m_spawn2.position, Quaternion.identity);
    }




}
