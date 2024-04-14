using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;
    public TMP_Text scoreText;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
    }

    private void Awake()
    {
        inst = this;
    }
}
