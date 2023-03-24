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

    public static GameManager instance;

    private void Awake()
    {

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
    }
}
