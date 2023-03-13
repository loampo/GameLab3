using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour
{
    //The box's current health point total
    public int currentHealth = 3;
    public GameObject fire;

    public void DamageBullet(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject a= Instantiate(fire, transform.position, Quaternion.identity);
            Destroy(a, 2f);

        }
    }
}
