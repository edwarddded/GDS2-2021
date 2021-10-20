using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScore : MonoBehaviour
{
    int score;
    public Text scoreText;

    void Start()
    {
        score = 1;
        score = PlayerPrefs.GetInt("daysSurvived");
        scoreText.text = score + " Days";
    }

}
