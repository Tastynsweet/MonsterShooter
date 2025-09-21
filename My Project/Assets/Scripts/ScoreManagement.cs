using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManagement : MonoBehaviour
{
    public static ScoreManagement instance;
    public TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        ScoreManagement.instance = this;
    }
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    public void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
