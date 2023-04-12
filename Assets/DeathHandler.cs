using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] public bool retry;
    public void Retry(){
        SceneManager.LoadScene("GameScene");
        retry = true;
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
        retry = false;
    }

}
