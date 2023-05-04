using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Linq;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    [SerializeField] private InputActionReference movement;
    [SerializeField] public ScoreUpdate scoreScript;
    [SerializeField] public BackgroundScroller backgroundScroller;
    [SerializeField] public RewardScript rewardScript;
    [SerializeField] public DeathHandler deathScript;
    [SerializeField] public PauseMenu pauseScript;

    [SerializeField] private Vector2 boundScreen;

    [SerializeField] private Rigidbody2D mainCharBody;

    [SerializeField] private float characterWidth;
    [SerializeField] private float characterHeight;
    [SerializeField] private Material material;
    [SerializeField] private bool isDissolving;
    [SerializeField] private float fade;
    [SerializeField] public bool enemyHit;
    [SerializeField] public bool gamePlayed;
    [SerializeField] public Stopwatch timer;
    [SerializeField] public IDictionary<string, int> individual_score_per_run = new Dictionary<string,int>();

    // Start is called before the first frame update
    void Start()
    {
        timer = new Stopwatch();
        timer.Start();
        Time.timeScale = 1f;
        //Debug.Log("Hello World!");
        scoreScript = GameObject.FindObjectOfType(typeof(ScoreUpdate)) as ScoreUpdate;
        backgroundScroller = GameObject.FindObjectOfType(typeof(BackgroundScroller)) as BackgroundScroller;
        rewardScript = GameObject.FindObjectOfType(typeof(RewardScript)) as RewardScript;
        deathScript = GameObject.FindObjectOfType(typeof(DeathHandler)) as DeathHandler;
        pauseScript = GameObject.FindObjectOfType(typeof(PauseMenu)) as PauseMenu;
        mainCharBody = GetComponent<Rigidbody2D>();

        boundScreen = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));
        characterWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        characterHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        material = GetComponent<SpriteRenderer>().material;
        isDissolving = false;
        fade = 1f;
        enemyHit = false;
        gamePlayed = true;


    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHit) {
            isDissolving = true;
        }
        if (isDissolving) {
            backgroundScroller.Speed = 0;
            backgroundScroller.GetComponent<AudioSource>().Stop();
            fade -= Time.deltaTime;
            if (fade <= 0f) {
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade);
        }

        Vector3 currentPosition = transform.position;
        if (transform.position.y >= boundScreen.y - characterHeight) {
            currentPosition.y = boundScreen.y - characterHeight;
            transform.position = currentPosition;
        } 
        if (transform.position.y <= -(boundScreen.y - characterHeight)) {
            currentPosition.y = -(boundScreen.y - characterHeight);
            transform.position = currentPosition;
        }

        if (pauseScript.isGamePaused) {

        }
    }
    void FixedUpdate(){
        if (!enemyHit) {
            mainCharBody.MovePosition(transform.position + (movement.action.ReadValue<Vector3>() * Time.fixedDeltaTime * speed));
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Reward") {
            other.GetComponent<RewardScript>().OnContact();
            pseudoDestroy(other);
            Destroy(other.gameObject, (float) 1.0);
            scoreScript.update_score();
        }
        else if (other.tag == "EnemyMeanie") {
            enemyHit = true;
            StartCoroutine(waiter());
        }
    }

    private void pseudoDestroy(Collider2D other){
        Renderer SpriteRender = other.GetComponent<SpriteRenderer>();
        Collider2D ObjectCollider = other.GetComponent<Collider2D>();
        SpriteRender.enabled = false;
        ObjectCollider.enabled = false;
    }

    public void saveGame(){
        var time = timer.Elapsed;
        PlayerPrefs.SetString("run_duration", time.ToString());
        var dateTime = System.DateTime.Now.ToString("MM/dd/yyyy, HH:mm");
        PlayerPrefs.SetString("run_datetime", dateTime);
        PlayerPrefs.SetString("game_run", PlayerPrefs.GetString("game_run") + dateTime + " - " + scoreScript.return_score().ToString() + ";");
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + scoreScript.return_score());
    }

    IEnumerator waiter() {
        yield return new WaitForSeconds(2);
        var time = timer.Elapsed;
        PlayerPrefs.SetString("run_duration", time.ToString());
        var dateTime = System.DateTime.Now.ToString("MM/dd/yyyy, HH:mm");
        PlayerPrefs.SetString("run_datetime", dateTime);
        PlayerPrefs.SetString("game_run", PlayerPrefs.GetString("game_run") + dateTime + " - " + scoreScript.return_score().ToString() + ";");
        //individual_score_per_run.Add(dateTime, scoreScript.return_score());
        //foreach(var entry in individual_score_per_run) {
        //        UnityEngine.Debug.Log(entry.Key + " - " + entry.Value.ToString() + "\n");
        //    }
        //UnityEngine.Debug.Log(time);
        SceneManager.LoadScene("DeathScene");
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + scoreScript.return_score());
    }
}
