using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardButtonBehaviour : MonoBehaviour
{
    public void BackToGameCompleted()
    {
        SceneManager.LoadScene("GameCompleted");
    }
}
