using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableBox : MonoBehaviour, IDamageable, IShootableBoox
{
    public int m_currentHealth;
    public GameObject m_effect; //animation
    public Animator animator;
    public Transform m_doorLocation;
    public bool m_needEffect;

    public void DamageBulletDoor(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        m_currentHealth -= damageAmount;
        //Check if health has fallen below zero
        if (m_currentHealth <= 0 && m_needEffect)
        {
            animator.SetBool("isBroken", true);
            GameObject a = Instantiate(m_effect, m_doorLocation.position, Quaternion.identity); //Instantiate the animation 
            Destroy(a, 2f); //destroy the animation after 2 seconds
        }else if (m_currentHealth <= 0 && !m_needEffect)
        {
            animator.SetBool("isBroken", true);
        }
    }
  

}
interface IShootableBoox
{
    public void DamageBulletDoor(int damageAmount);
}


