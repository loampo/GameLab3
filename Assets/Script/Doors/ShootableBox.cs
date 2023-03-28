using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour, IDamageable, IShootableBoox
{
    public int m_currentHealth;


    public void DamageBulletDoor(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        m_currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (m_currentHealth <= 0)
        {

            Destroy(gameObject);

        }
    }

   
}
interface IShootableBoox
{
    public void DamageBulletDoor(int damageAmount);
}
