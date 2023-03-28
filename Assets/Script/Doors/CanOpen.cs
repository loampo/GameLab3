using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOpen : MonoBehaviour
{
    
    public Animator animator;
    


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.PLAYER) && PlayerInformation.m_instance.m_RedKey == true)
        {
            animator.SetBool("Open",true);            
        }
        if (other.gameObject.CompareTag(Constants.PLAYER) && GameManager.m_instance.bossDeath==true)
        {
            animator.SetBool("BossDefeat", true);
        }
       
    }
}
