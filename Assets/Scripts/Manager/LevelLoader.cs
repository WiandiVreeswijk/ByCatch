using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static int currentLevel = 1;

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
