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


    private void Update()
    {

        EnemyTarget();
       
    }


    private void EnemyTarget()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

        GameObject target = GameObject.FindGameObjectWithTag(Constants.ENEMY);
        if (target.layer == 3 && Vector3.Distance(transform.position, target.transform.position) > focusDistance)
        {
            try
            {
                Vector3 targetDirection = target.transform.position - transform.position;

                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

                transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

                transform.rotation = Quaternion.LookRotation(newDirection);
                
            }
            catch (System.Exception)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
            }
        }

        
    }

    


    protected override void ColorBullet()
    {
        Color targetColor = new Color(Color.green.r, Color.green.g, Color.green.b);
        gameObject.GetComponent<MeshRenderer>().material.color = targetColor;

    }
}







