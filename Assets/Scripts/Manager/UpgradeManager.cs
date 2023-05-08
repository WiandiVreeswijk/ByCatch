using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeManager : MonoBehaviour
{
    public static bool UPGRADE_BOUGHT = false;

    public static bool proFisherBought, ecoExpertBought, smartSellerBought, expertFisherBought = false;

    public GameObject proFisher, ecoExpert, smartSeller, expertFisher;
    private void Start()
    {
        if (proFisherBought)
        {
            Destroy(proFisher);
            smartSeller.SetActive(true);
        }
        if (ecoExpertBought)
        {
            Destroy(ecoExpert);
            expertFisher.SetActive(true);

        }
        if (smartSellerBought)
            Destroy(smartSeller);
    }
    public void ProFisher()
    {
        if (ScoreManager.TOTAL_CASH >= 40)
        {
            ScoreManager.TOTAL_CASH -= 40;
            HookBehaviour.MOVE_SPEED *= 1.5f;
            UPGRADE_BOUGHT = true;
            proFisherBought = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/CatchMoneyMaker");
            smartSeller.SetActive(true);
            Destroy(EventSystem.current.currentSelectedGameObject);
        }
    }

    public void EcoExpert()
    {
        if (ScoreManager.TOTAL_CASH >= 60)
        {
            ScoreManager.TOTAL_CASH -= 60;
            ScoreManager.mackerelEcoValue *= 2;
            ScoreManager.sableFishEcoValue *= 2;
            UPGRADE_BOUGHT = true;
            ecoExpertBought = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/CatchMoneyMaker");
            expertFisher.SetActive(true);
            Destroy(EventSystem.current.currentSelectedGameObject);
        }
    }
    public void SmartSeller()
    {
        if (ScoreManager.TOTAL_CASH >= 80)
        {
            ScoreManager.TOTAL_CASH -= 80;
            ScoreManager.mackerelCashValue *= 2;
            ScoreManager.sableFishCashValue *= 2;
            UPGRADE_BOUGHT = true;
            smartSellerBought = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/CatchMoneyMaker");
            Destroy(EventSystem.current.currentSelectedGameObject);
        }
    }
    public void ExpertFisher()
    {
        if (ScoreManager.TOTAL_CASH >= 100)
        {
            ScoreManager.TOTAL_CASH -= 100;
            HookBehaviour.MOVE_SPEED *= 2f;
            UPGRADE_BOUGHT = true;
            expertFisherBought = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/CatchMoneyMaker");
            Destroy(EventSystem.current.currentSelectedGameObject);
        }
    }
}
