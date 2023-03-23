using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HominMissleBullet : Bullet
{



    [SerializeField]
    private float speed = 15;

    [SerializeField]
    private float rotationSpeed = 1000;

    [SerializeField]
    private float focusDistance = 5;

    private Transform target;


    private void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.ENEMY);
        EnemyTarget(enemies);
    }



    private void Update()
    {
        MovingMissle();
        if (target) HomingMissle(target);


    }


    private void MovingMissle()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
    }


    private void EnemyTarget(GameObject[] enemies)
    {
        target = null;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.layer != 3) continue;
            if (!target && Vector3.Distance(transform.position, enemy.transform.position) < focusDistance)
            {
                target = enemy.transform;
            }
            else
            {
                float targetDistance = Vector3.Distance(transform.position, target.transform.position);
                float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

                if (enemyDistance < targetDistance)
                {
                    target = enemy.transform;

                }

            }
        }
    }


    private void HomingMissle(Transform target)
    {
        Vector3 targetDirection = target.transform.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

        transform.rotation = Quaternion.LookRotation(newDirection);

    }


    protected override void CollisionDetection(Collision collision)
    {
        if (collision.gameObject.CompareTag(Constants.ENEMY))
        {
            collision.transform.GetComponent<EnemyBase>().DamageBullet(m_damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(Constants.WALL))
        {
            Destroy(gameObject);

        }

    }


    protected override void ColorBullet()
    {
        Color targetColor = new Color(Color.green.r, Color.green.g, Color.green.b);
        gameObject.GetComponent<MeshRenderer>().material.color = targetColor;

    }
}







