using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int TOTAL_CASH;
    public static int TOTAL_ECOSCORE;

    public TextMeshProUGUI cashText, ecoScoreText;

    [Header("Seabass")]
    private int seabassCashValue = 10;
    private int seabassEcoValue = -4;

    [Header("Mackerel")]
    public static int mackerelCashValue = 5;
    public static int mackerelEcoValue = 6;

    [Header("BlueFinTuna")]
    public static int tunaCashValue = 40;
    public static int tunaEcoValue = -20;

    [Header("SableFish")]
    public static int sableFishCashValue = 10;
    public static int sableFishEcoValue = 20;

    private void Start()
    {
        cashText.text = TOTAL_CASH.ToString();
        ecoScoreText.text = TOTAL_ECOSCORE.ToString();
    }

    public void CheckValue(GameObject fishCaught)
    {
        if (fishCaught.CompareTag("Seabass"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/CatchMoneyMaker");
            TOTAL_CASH += seabassCashValue;
            TOTAL_ECOSCORE += seabassEcoValue;
        }else if (fishCaught.CompareTag("Mackerel")){
            FMODUnity.RuntimeManager.PlayOneShot("event:/CatchEcoFriendly");
            TOTAL_CASH += mackerelCashValue;
            TOTAL_ECOSCORE += mackerelEcoValue;
        }else if (fishCaught.CompareTag("BluefinTuna"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/CatchMoneyMaker");
            TOTAL_CASH += tunaCashValue;
            TOTAL_ECOSCORE += tunaEcoValue;
        }else if (fishCaught.CompareTag("SableFish"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/CatchEcoFriendly");
            TOTAL_CASH += sableFishCashValue;
            TOTAL_ECOSCORE += sableFishEcoValue;
        }
        cashText.text = TOTAL_CASH.ToString();
        ecoScoreText.text = TOTAL_ECOSCORE.ToString();
    }

}
