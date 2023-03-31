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


    

    private void Awake()
    {
        m_EnemyWeapon = GetComponent<EnemyWeapon>(); //Get the component for the weapon 
    }

    public abstract void DamageBullet(int damageAmount);
    
}
interface IDamageable
{
    
}

