using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCollector : MonoBehaviour
{
    public int Score = 0;
    public Text ScoreText;

    public void updateScore(int score)
    {
        Score += score;
        ScoreText.text = "Score : " + Score;
    }
}
