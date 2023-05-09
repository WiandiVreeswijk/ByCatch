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

    private void Awake()
    {
        StartCoroutine(BlackScreenFade());
    }

    private IEnumerator BlackScreenFade()
    {
        yield return new WaitForSeconds(1f);
        blackScreen.DOFade(0f, 2f);
    }

    public void StartGame()
    {
        blackScreen.DOFade(1f, 2f).OnComplete(() =>
         {
             SceneManager.LoadScene("FirstLevel", LoadSceneMode.Single);
         });
    }

    public void LoadLevel()
    {
        if (currentLevel == 1)
        {
            SceneManager.LoadScene("SecondLevel", LoadSceneMode.Single);
            currentLevel = 2;
        }
        else if (currentLevel == 2)
        {
            SceneManager.LoadScene("ThirdLevel", LoadSceneMode.Single);
            currentLevel = 3;
        }
    }

}
