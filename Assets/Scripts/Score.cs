using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TMP_Text Points;
    public int ScoreAmount = 0;

    public TMP_Text Seconds;
    public float InitialSecond = 0f;
    public float SecondSum = 0.1f;

    void Update()
    {
        Points.text = "Points: " + (int)ScoreAmount;

        Seconds.text = (int)InitialSecond + "s";
        InitialSecond += Time.unscaledDeltaTime;
    }

    public void AddScore()
    {
        ScoreAmount++;
    }
}
