using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private CursorLockMode m_CursorLockModeNone = CursorLockMode.None;
    private bool m_CursorVisibleTrue = true;
    




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Constants.PLAYER))
        {
            Time.timeScale = 0;
            UIManager.m_instance.m_winScene.SetActive(true);
            Cursor.lockState = m_CursorLockModeNone;
            Cursor.visible = m_CursorVisibleTrue;
        }
    }
}
