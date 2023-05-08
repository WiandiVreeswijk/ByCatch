using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRetriever : MonoBehaviour
{
    public TextMeshProUGUI totalCash, totalEcoScore;

    private void Start()
    {
        totalCash.text = "Total cash \n" + ScoreManager.TOTAL_CASH.ToString() + "$";
        totalEcoScore.text = "Ecoscore \n" + ScoreManager.TOTAL_ECOSCORE.ToString();
    }

    private void FixedUpdate()
    {
        if (UpgradeManager.UPGRADE_BOUGHT)
        {
            totalCash.text = "Total cash \n" + ScoreManager.TOTAL_CASH.ToString() + "$";
            UpgradeManager.UPGRADE_BOUGHT = false;
        }
    }
}
