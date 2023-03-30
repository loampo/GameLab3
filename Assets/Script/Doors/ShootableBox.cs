using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour, IDamageable, IShootableBoox
{
    public int m_currentHealth;

    public Animator animator;

    public void DamageBulletDoor(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        m_currentHealth -= damageAmount;
        if (m_currentHealth <= 0) animator.SetBool("isBroken", true);
        //Check if health has fallen below zero

    }

  

}
interface IShootableBoox
{
    public void DamageBulletDoor(int damageAmount);
}


