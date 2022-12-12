using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text txtFinalScore;
    void Start()
    {
        
    }

    void Update()
    {
        txtFinalScore.text = Scoring.score.ToString();
    }
}
