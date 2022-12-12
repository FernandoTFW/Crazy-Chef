using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text ScoreText;
    public static int score = 0;


    public GameObject Score;
    public GameObject YouText;

    void Start()
    {
        score = 0;
    }

    public static void AddScore(int newScore)
    {
        score += newScore;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();

       
    }
}
