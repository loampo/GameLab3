using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag(Constants.AMMO))
        {
            Destroy(other.gameObject);
            
        }
        if (other.transform.CompareTag(Constants.SHIELD))
        {
            Destroy(other.gameObject);
 
        }
    }
}
