using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int score=0;
    public int astronautScorePoints;

    

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
       ScoreText.text = score.ToString();
    }



}
