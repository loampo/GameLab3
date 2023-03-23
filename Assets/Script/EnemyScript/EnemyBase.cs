using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    
    public int m_currentHealth; //the enemy current healt
    public GameObject m_fire; //animation for enemy destruction 
    public int m_enemyScorePoints; //how much score you will get 
    public float m_maxDistance; //distance at which he starts shooting
    protected EnemyWeapon m_EnemyWeapon; 
    public Transform m_player;


    private void OnBecameVisible()
    {
        gameObject.layer = 3; //visible in camera

    }


    private void OnBecameInvisible()
    {
        gameObject.layer = 0; //non visible in camera
    }

    private void Awake()
    {
        m_EnemyWeapon = GetComponent<EnemyWeapon>(); //Get the component for the weapon 
    }

    public virtual void DamageBullet(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        m_currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (m_currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject a= Instantiate(m_fire, transform.position, Quaternion.identity); //Instantiate the animation 
            Destroy(a, 2f); //destroy the animation after 2 seconds
            GameManager.instance.m_score += m_enemyScorePoints; //increment scoore 


        }
    }
}
