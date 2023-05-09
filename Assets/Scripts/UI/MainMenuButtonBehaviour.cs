using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonBehaviour : MonoBehaviour
{
    public GameObject mainMenu, instructionsMenu1, instructionsMenu2;

    public void OpenInstructionsMenu1()
    {
        mainMenu.SetActive(false);
        instructionsMenu1.SetActive(true);
        instructionsMenu2.SetActive(false);
    }
    public void OpenInstructionsMenu2()
    {
        mainMenu.SetActive(false);
        instructionsMenu1.SetActive(false);
        instructionsMenu2.SetActive(true);
    }
    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        instructionsMenu1.SetActive(false);
        instructionsMenu2.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
