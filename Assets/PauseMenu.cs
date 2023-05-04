using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGamePaused = false;
    public GameObject pauseMenu;

    [SerializeField] public BackgroundScroller backgroundScroller;
    [SerializeField] public Character characterScript;

    // Update is called once per frame
    void Start()
    {   
        backgroundScroller = GameObject.FindObjectOfType(typeof(BackgroundScroller)) as BackgroundScroller;
        characterScript = GameObject.FindObjectOfType(typeof(Character)) as Character;
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (!characterScript.enemyHit){
            if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
        }
    }
    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        backgroundScroller.GetComponent<AudioSource>().Play();
    }
    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        backgroundScroller.GetComponent<AudioSource>().Stop();
    }

    public void Menu() {
        characterScript.saveGame();
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() {
        characterScript.saveGame();
        Application.Quit();
    }
}
