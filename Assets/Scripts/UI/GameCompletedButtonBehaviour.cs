using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameCompletedButtonBehaviour : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    private void Start()
    {
        finalScore.text = ScoreManager.TOTAL_ECOSCORE.ToString();
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        ResetGameVariables();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenLeaderboard()
    {
        SceneManager.LoadScene("Leaderboard", LoadSceneMode.Single);
    }

    private void ResetGameVariables()
    {
        ScoreManager.TOTAL_ECOSCORE = 0;
        ScoreManager.TOTAL_CASH = 0;
        UpgradeManager.proFisherBought = false;
        UpgradeManager.smartSellerBought = false;
        UpgradeManager.ecoExpertBought = false;
        UpgradeManager.expertFisherBought = false;

        HookBehaviour.MOVE_SPEED = 3f;
        ScoreManager.mackerelCashValue = 5;
        ScoreManager.mackerelEcoValue = 6;
        ScoreManager.sableFishCashValue = 10;
        ScoreManager.sableFishEcoValue = 20;
    }
}
