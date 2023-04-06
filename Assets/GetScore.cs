using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    [SerializeField] private ScoreUpdate scoreUpdate;
    [SerializeField] private Character character;
    [SerializeField] public Text totalPoints;

    public void OpenStore(){
        //scoreUpdate = GameObject.FindObjectOfType(typeof(ScoreUpdate)) as ScoreUpdate;
        //character = GameObject.FindObjectOfType(typeof(Character)) as Character;

        //var score = scoreUpdate.scoreCount;
        totalPoints.text = "Available points to spend: " + PlayerPrefs.GetInt("score").ToString();
    }
}

