using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;


    [SerializeField] public ScoreUpdate scoreScript;

    [SerializeField] private Vector2 boundScreen;

    [SerializeField] private Rigidbody2D mainCharBody;

    [SerializeField] private float characterWidth;
    [SerializeField] private float characterHeight;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
        scoreScript = GameObject.FindObjectOfType(typeof(ScoreUpdate)) as ScoreUpdate;
        mainCharBody = GetComponent<Rigidbody2D>();

        //mainCamera = FindObjectOfType<Camera>();
        boundScreen = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0));
        characterWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        characterHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;


    }

    // Update is called once per frame
    void Update()
    {
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
     mainCharBody.MovePosition(transform.position + (new Vector3(0, Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime * speed));
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Reward") {
            other.GetComponent<RewardScript>().OnContact();
            pseudoDestroy(other);
            Destroy(other.gameObject, (float) 1.0);
            scoreScript.update_score();
        }
        else if (other.tag == "EnemyMeanie") {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void pseudoDestroy(Collider2D other){
        Renderer SpriteRender = other.GetComponent<SpriteRenderer>();
        Collider2D ObjectCollider = other.GetComponent<Collider2D>();
        SpriteRender.enabled = false;
        ObjectCollider.enabled = false;
    }
}
