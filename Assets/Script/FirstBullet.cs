using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBullet : Bullet
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
}
