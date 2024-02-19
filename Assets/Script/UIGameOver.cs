using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI  scoreText;
    static Score score;
    void Awake() {
        score = FindObjectOfType<Score>();
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (score!= null)
        {
            
        }
    }

    void Start()
    {
        scoreText.text="Your Score: " + score.GetScore();
    }


}
