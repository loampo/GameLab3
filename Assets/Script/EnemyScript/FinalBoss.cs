using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : EnemyBase
{
    

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(Player.position, transform.position);
        if (distanceToPlayer < maxDistance)
        {

            transform.LookAt(Player);
            enemyWeapon.Shooting();



        }

    }
}
