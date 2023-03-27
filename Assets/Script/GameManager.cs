using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int m_score=0;
    public int m_astronautScorePoints;
    public Camera m_mainCamera;
    public Camera m_cameraBack;

    [SerializeField] private TextMeshProUGUI ScoreText;

    private CursorLockMode m_CursorLockModeLocked = CursorLockMode.Locked;
    private bool m_CursorVisibleFalse = true;
    private CursorLockMode m_CursorLockModeNone = CursorLockMode.None;
    private bool m_CursorVisibleTrue = true;

    public GameObject m_player;


    public static GameManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        //Controllo in più
        if (instance == null)
            instance = this;

    }

   
    private void Update()
    {
        ScoreText.text = m_score.ToString();
        if (Input.GetKey(KeyCode.R)) //press key
        {
            m_mainCamera.enabled = false;
            m_cameraBack.enabled = true;
            UIManager.m_instance.SwitchFromMainCameraToBack();
        }else
        {
            m_mainCamera.enabled = true;
            m_cameraBack.enabled = false;
            UIManager.m_instance.SwitchFromBackCameraToMainCamera();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }


    }


    public void ResumeGame()
    {
        if (Time.timeScale == 0)
        {
            UIManager.m_instance.pause.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = m_CursorLockModeLocked;
            Cursor.visible =m_CursorVisibleFalse;
            m_player.SetActive(true);
            m_mainCamera.enabled = false;
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void Pause()
    {
        UIManager.m_instance.pause.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = m_CursorLockModeNone; //Impedisce al cursore di uscire dallo schermo
        Cursor.visible = m_CursorVisibleTrue; // Nasconde il cursore del mouse
        m_player.SetActive(false);
        m_mainCamera.enabled = true;
    }
}
