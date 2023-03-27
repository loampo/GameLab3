using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOpen : MonoBehaviour
{
    public Animator animator;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && PlayerInformation.m_instance.m_RedKey == true)
        {
            Debug.Log("open");
            animator.SetBool("Open",true);            
        }
    }
}
