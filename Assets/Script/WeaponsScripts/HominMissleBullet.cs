using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HominMissleBullet : Bullet
{


    [SerializeField]
    private float m_Speed = 15; //bullet speed

    [SerializeField]
    private float m_RotationSpeed = 1000; //rotation for the missle

    [SerializeField]
    private float m_FocusDistance = 5; //max distance

    private Transform m_Target; //target for the missle


    private void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Constants.ENEMY); //take enemy from all the map
        EnemyTarget(enemies); //target 
    }



    private void Update()
    {
        MovingMissle();
        if (m_Target) HomingMissle(m_Target);


    }


    private void MovingMissle()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * m_Speed, Space.Self); //moving missle with velocity 
    }


    private void EnemyTarget(GameObject[] enemies)
    {
        m_Target = null;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.layer != 3) continue; //layer 3
            if(!m_Target && Vector3.Distance(transform.position, enemy.transform.position) < m_FocusDistance ) //distance for the missle
            {
                m_Target = enemy.transform; //take the hit
            }
            else 
            {
                float targetDistance = Vector3.Distance(transform.position, m_Target.transform.position);
                float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);

                if (enemyDistance < targetDistance)
                {
                    m_Target = enemy.transform;

                }

            } 
        }
    }


    private void HomingMissle(Transform target)
    {
        Vector3 targetDirection = target.transform.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, m_RotationSpeed * Time.deltaTime, 0.0F);

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







