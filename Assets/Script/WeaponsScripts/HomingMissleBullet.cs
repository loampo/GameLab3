using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissleBullet : Bullet
{




    





    protected override void ColorBullet()
    {
        Color targetColor = new Color(Color.red.r, Color.red.g, Color.red.b);
        gameObject.GetComponent<MeshRenderer>().material.color = targetColor;

    }
}
