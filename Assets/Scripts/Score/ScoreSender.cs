using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSender : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI scoreText;
    private int finalScore;

    private void Start()
    {
        finalScore = ScoreManager.TOTAL_ECOSCORE;
        scoreText.text = ScoreManager.TOTAL_ECOSCORE.ToString();
    }
    public void SendScore()
    {
        HighScores.UploadScore(nameInput.text, finalScore);
    }
}
