using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBullet : Bullet
{
    private void Awake()
    {
        ColorBullet();
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
