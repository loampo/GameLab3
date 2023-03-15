using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    //The box's current health point total
    public int currentHealth;
    public GameObject fire;
    public int enemyScorePoints;









    private void OnBecameVisible()
    {
        gameObject.layer = 3;

    }


    private void OnBecameInvisible()
    {
        gameObject.layer = 0;
    }


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
            GameManager.instance.score += enemyScorePoints;


        }
    }
}
