using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : EnemyBase
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


        }
        else
        {
            UIManager.m_instance.m_lockImage.SetActive(false);
        }


    }
}
