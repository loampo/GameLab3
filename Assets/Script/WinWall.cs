using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWall : MonoBehaviour
{
    private CursorLockMode m_CursorLockModeNone = CursorLockMode.None;
    private bool m_CursorVisibleTrue = true;


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(Constants.WIN))  //if i collider with something with that tag REDKEY
        {
            Time.timeScale = 0;
            UIManager.m_instance.m_winScene.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            


        }
    }
}
