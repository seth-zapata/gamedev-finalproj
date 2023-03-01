using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{

    [SerializeField] private GameObject scoreGameObject;
    [SerializeField] private Text score;
    [SerializeField] int scoreCount;

    void Start() {
        score.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreGameObject = GameObject.FindWithTag("Score");
        var scoreComponent = score.GetComponent<ScoreUpdate>();
        //scoreComponent.update_score();
    }

    public void update_score() {
        scoreCount += 1;
        score.text = "Score:  " + scoreCount.ToString();
    }
}
