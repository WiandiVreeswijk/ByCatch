using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    private static int currentLevel = 1;
    public Image blackScreen;

    private const string FIRST_LEVEL_SCENE = "FirstLevel";
    private const string SECOND_LEVEL_SCENE = "SecondLevel";
    private const string THIRD_LEVEL_SCENE = "ThirdLevel";
    private const string SHOP_SCENE = "Shop";
    private const string GAME_COMPLETED = "GameCompleted";


    private void Awake()
    {
        StartCoroutine(BlackScreenFade());
    }

    private IEnumerator BlackScreenFade()
    {
        yield return new WaitForSeconds(1f);
        blackScreen.DOFade(0f, 2f).OnComplete(() =>
        {
            blackScreen.enabled = false;
        });
    }

    public void StartGame()
    {
        blackScreen.enabled = true;
        blackScreen.DOFade(1f, 2f).OnComplete(() =>
         {
             SceneManager.LoadScene(FIRST_LEVEL_SCENE, LoadSceneMode.Single);
         });
    }

    public void LoadShop()
    {
        blackScreen.enabled = true;
        blackScreen.DOFade(1f, 2f).OnComplete(() =>
        {
            SceneManager.LoadScene(SHOP_SCENE, LoadSceneMode.Single);
        });
    }
    public void LoadGameCompleted()
    {
        blackScreen.enabled = true;
        blackScreen.DOFade(1f, 2f).OnComplete(() =>
        {
            SceneManager.LoadScene(GAME_COMPLETED, LoadSceneMode.Single);
        });
    }

    public void LoadLevel()
    {
        blackScreen.enabled = true;
        switch (currentLevel)
        {
            case 1:
                blackScreen.DOFade(1f, 2f).OnComplete(() =>
                {
                    SceneManager.LoadScene(SECOND_LEVEL_SCENE, LoadSceneMode.Single);
                });
                currentLevel = 2;
                break;
            case 2:
                blackScreen.DOFade(1f, 2f).OnComplete(() =>
                {
                    SceneManager.LoadScene(THIRD_LEVEL_SCENE, LoadSceneMode.Single);
                });
                currentLevel = 3;
                break;
            default:
                // Handle invalid level number
                break;
        }
    }
}
