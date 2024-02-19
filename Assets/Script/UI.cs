using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] Slider health;
    [SerializeField] Health playerHealth;
    [Header("Score")]
    [SerializeField]TextMeshProUGUI score;
    Score playerScore;
    private void Awake() {
        playerScore = FindObjectOfType<Score>();
    }
    void Start()
    {
        health.maxValue=playerHealth.GetHealth();

    }

    void Update()
    {
        health.value = playerHealth.GetHealth();
        score.text = playerScore.GetScore().ToString("000000000000");
    }

}
