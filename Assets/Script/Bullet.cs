using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public int damage;
    
    

    public void OnCollisionEnter(Collision collision)
    {

        CollisionDetection(collision);

    }

    protected virtual void CollisionDetection(Collision collision)
    {
        if (collision.gameObject.CompareTag(Constants.ENEMY))
        {
            collision.transform.GetComponent<ShootableBox>().DamageBullet(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(Constants.WALL))
        {
            Destroy(gameObject);

        }

    }

    protected abstract void ColorBullet();
    


}
