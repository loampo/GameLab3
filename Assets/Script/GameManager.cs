using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int m_score=0;
    public int m_astronautScorePoints;
    public Camera m_mainCamera;
    public Camera m_cameraBack;
    public Camera m_mapCamera;
    private bool m_mapCameraActive = false;

    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI ScoreFinalText;

    private CursorLockMode m_CursorLockModeLocked = CursorLockMode.Locked;
    private bool m_CursorVisibleFalse = true;
    private CursorLockMode m_CursorLockModeNone = CursorLockMode.None;
    private bool m_CursorVisibleTrue = true;

    public GameObject m_player;

    public bool bossDeath;

    public static GameManager m_instance;

    private void Awake()
    {
        m_mainCamera.enabled = true;
        m_cameraBack.enabled = false;
        m_mapCamera.enabled = false;
        //Controllo in più
        if (m_instance == null)
            m_instance = this;

    }


    private void Update()
    {
        ScoreText.text = m_score.ToString();
        ScoreFinalText.text = m_score.ToString();


        if (Input.GetKeyDown(KeyCode.R) && Time.timeScale == 1) //press key
        {
            m_cameraBack.enabled = true;
            m_mainCamera.enabled = false;
            m_mapCamera.enabled = false;
            UIManager.m_instance.SwitchFromMainCameraToBack();
        }
        else if (Input.GetKeyUp(KeyCode.R) && Time.timeScale == 1)
        {
            m_cameraBack.enabled = false;
            m_mainCamera.enabled = true;
            m_mapCamera.enabled = false;
            UIManager.m_instance.SwitchFromBackCameraToMainCamera();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !m_mapCameraActive && Time.timeScale == 1)
        {
            Pause();
        }
        if (Input.GetKeyDown(KeyCode.Tab) && Time.timeScale == 1)
        {
            if (!m_mapCameraActive)
            {
                m_mapCameraActive = true;
                m_mapCamera.enabled = true;
                m_mainCamera.enabled = false;
                m_cameraBack.enabled = false;
                UIManager.m_instance.SwitchFromMainCameraToBack();
            }
            else
            {
                m_mapCameraActive = false;
                m_mapCamera.enabled = false;
                m_mainCamera.enabled = true;
                m_cameraBack.enabled = false;
                UIManager.m_instance.SwitchFromBackCameraToMainCamera();
            }
        }
    }


    public void ResumeGame()
    {
        if (Time.timeScale == 0)
        {
            UIManager.m_instance.m_pause.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = m_CursorLockModeLocked;
            Cursor.visible =m_CursorVisibleFalse;
            m_player.SetActive(true);
            m_mainCamera.enabled = true;
            m_mapCameraActive = false;
            UIManager.m_instance.SwitchFromBackCameraToMainCamera();
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
        UIManager.m_instance.m_pause.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = m_CursorLockModeNone; //Impedisce al cursore di uscire dallo schermo
        Cursor.visible = m_CursorVisibleTrue; // Nasconde il cursore del mouse
        m_player.SetActive(false);
        //m_mainCamera.enabled = true;
    }

    public void Retry()
    {
        
        
        if (PlayerInformation.m_instance.m_lives == 3)
        {
            PlayerInformation.m_instance.m_lives -= 1;
            PlayerInformation.m_instance.m_healt = 100;
            UIManager.m_instance.m_lives[0].enabled = false;
            UIManager.m_instance.m_loseScene.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = m_CursorLockModeLocked;
            Cursor.visible = m_CursorVisibleFalse;
            

        }
        else if(PlayerInformation.m_instance.m_lives == 2)
        {
            PlayerInformation.m_instance.m_lives -= 1;
            PlayerInformation.m_instance.m_healt = 100;
            UIManager.m_instance.m_lives[1].enabled = false;
            UIManager.m_instance.m_loseScene.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = m_CursorLockModeLocked;
            Cursor.visible = m_CursorVisibleFalse;
            

        }
        else if (PlayerInformation.m_instance.m_lives == 1)
        {
            PlayerInformation.m_instance.m_lives -= 1;
            PlayerInformation.m_instance.m_healt = 100;
            UIManager.m_instance.m_lives[2].enabled = false;
            UIManager.m_instance.m_loseScene.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = m_CursorLockModeLocked;
            Cursor.visible = m_CursorVisibleFalse;
            

        }
        m_player.SetActive(true);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex -1);
        Time.timeScale = 1;
    }

   


}
