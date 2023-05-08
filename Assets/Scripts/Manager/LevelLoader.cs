using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static bool level2Loaded, level3Loaded = false;
    public void LoadLevel()
    {
        if (!level2Loaded)
        {
            SceneManager.LoadScene("SecondLevel", LoadSceneMode.Single);
            level2Loaded = true;
        }else if (!level3Loaded)
        {
            SceneManager.LoadScene("ThirdLevel", LoadSceneMode.Single);
            level3Loaded = true;
        }
    }
}
