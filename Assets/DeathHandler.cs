using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    public void Retry(){
        SceneManager.LoadScene("GameScene");
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

}
