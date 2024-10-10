using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreDisplayText;
    [SerializeField] private TextMeshProUGUI highScoreDisplayText;
    [SerializeField] private Transform playerTransform;

    private float startPos;
    private int currentScore;
    private int highScore;

    void Start()
    {
        startPos = playerTransform.position.y;
        LoadHighScore();
    }

    
    void Update()
    {
        currentScore = Mathf.Abs(Mathf.RoundToInt(playerTransform.position.y - startPos));

        if(currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }

        scoreDisplayText.text = currentScore.ToString();
        highScoreDisplayText.text = highScore.ToString();

    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }
}
