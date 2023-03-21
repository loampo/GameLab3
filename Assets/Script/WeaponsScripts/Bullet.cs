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

    protected abstract void CollisionDetection(Collision collision);
    


    protected abstract void ColorBullet();
    


}
