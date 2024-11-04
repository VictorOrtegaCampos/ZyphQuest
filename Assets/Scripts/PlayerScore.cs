using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] Text scoreText;

    void Start()
    {
        
        scoreText.text = "Puntuaci�n: " + 0;
    }

    public void AddScore(int scoreParameter)
    {
        score += scoreParameter;
        scoreText.text = "Puntuaci�n: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}
