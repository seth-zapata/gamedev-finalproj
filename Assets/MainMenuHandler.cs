using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void History() {
        SceneManager.LoadScene("History");
    }

    public void Upgrades() {
        //SceneManager.LoadScene("")
    }

    public void QuitGame() {
        Application.Quit();
    }
}
