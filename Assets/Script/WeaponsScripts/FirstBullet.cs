using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBullet : Bullet
{
   

   
    protected override void CollisionDetection(Collision collision)
    {
        if (collision.gameObject.CompareTag(Constants.ENEMY))
        {
            collision.transform.GetComponent<EnemyBase>().DamageBullet(m_damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(Constants.WALL))
        {
            Destroy(gameObject);
            
        }
        if (collision.gameObject.CompareTag(Constants.ENEMYBULLET))
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag(Constants.PLAYERBULLET))
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag(Constants.SHOOTABLEBOX))
        {
            collision.transform.GetComponent<ShootableBox>().DamageBulletDoor(m_damage);
            Destroy(gameObject);
        }
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.ASTRONAUT))
        {
            Destroy(gameObject);
        }
    }


}
