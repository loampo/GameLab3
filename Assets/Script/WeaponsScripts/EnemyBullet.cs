using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    private void Awake()
    {
        ColorBullet();
    }


    protected override void ColorBullet()
    {
        Color targetColor = new Color(Color.green.r, Color.green.g, Color.green.b);
        gameObject.GetComponent<MeshRenderer>().material.color = targetColor;

    }

    protected override void CollisionDetection(Collision collision)
    {
        if (collision.gameObject.CompareTag(Constants.PLAYER))
        {
            collision.transform.GetComponent<PlayerInformation>().Damage(m_damage);
            Debug.Log(collision);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(Constants.WALL))
        {
            Destroy(gameObject);

        }
        if (collision.gameObject.CompareTag(Constants.PLAYERBULLET))
        {
            Destroy(gameObject);

        }
        
    }
}
