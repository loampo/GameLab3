using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : EnemyBase, IDamageable
{
    

    // Update is called once per frame
    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(m_player.position, transform.position); //distance from the player 
        if (distanceToPlayer < m_maxDistance)
        {

            transform.LookAt(m_player); //enemy always look to the player
            m_EnemyWeapon.Shooting(); //shooting system
            UIManager.m_instance.m_lockImage.SetActive(true);
            if (m_currentHealth <= 0) GameManager.m_instance.bossDeath = true;

        }
        else
        {
            UIManager.m_instance.m_lockImage.SetActive(false);
        }
        

    }


    public override void DamageBullet(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        m_currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (m_currentHealth <= 0)
        {
            Destroy(gameObject);
            GameObject a = Instantiate(m_fire, transform.position, Quaternion.identity); //Instantiate the animation 
            Destroy(a, 2f); //destroy the animation after 2 seconds
            GameManager.m_instance.m_score += m_enemyScorePoints; //increment scoore 
            GameManager.m_instance.bossDeath = true;

        }
    }
}
