using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;


    [SerializeField] public ScoreUpdate scoreScript;
    [SerializeField] public BackgroundScroller backgroundScroller;
    [SerializeField] public RewardScript rewardScript;

    [SerializeField] private Vector2 boundScreen;

    [SerializeField] private Rigidbody2D mainCharBody;

    [SerializeField] private float characterWidth;
    [SerializeField] private float characterHeight;
    [SerializeField] private Material material;
    [SerializeField] private bool isDissolving;
    [SerializeField] private float fade;
    [SerializeField] public bool enemyHit;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello World!");
        scoreScript = GameObject.FindObjectOfType(typeof(ScoreUpdate)) as ScoreUpdate;
        backgroundScroller = GameObject.FindObjectOfType(typeof(BackgroundScroller)) as BackgroundScroller;
        rewardScript = GameObject.FindObjectOfType(typeof(RewardScript)) as RewardScript;
        mainCharBody = GetComponent<Rigidbody2D>();

        //mainCamera = FindObjectOfType<Camera>();
        boundScreen = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));
        characterWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        characterHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;

        material = GetComponent<SpriteRenderer>().material;
        isDissolving = false;
        fade = 1f;
        enemyHit = false;


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
            //Debug.Log("Dissolving...");
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
    }
    void FixedUpdate(){
        if (!enemyHit) {
            mainCharBody.MovePosition(transform.position + (new Vector3(0, Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime * speed));
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

    IEnumerator waiter() {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
