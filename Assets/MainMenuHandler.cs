using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] private List<string> skillNames;
    public void Start() {
        string[] input = {"speed_upgrades", "strength_upgrades", "armor_upgrades", "health_upgrades", "shield_upgrades", "revive_upgrades"};
        skillNames.AddRange(input);
        foreach (var name in skillNames) {
            if (!PlayerPrefs.HasKey(name)) {
                Debug.Log("setting " + name);
                PlayerPrefs.SetInt(name, 0);
            }
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void History() {
        SceneManager.LoadScene("History");
    }

    public void Upgrades() {
        SceneManager.LoadScene("Store");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
