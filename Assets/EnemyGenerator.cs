using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    [SerializeField] private GameObject EnemyMeaniePrefab;

    [SerializeField] private GameObject EnemyClone;
    [SerializeField] private float speed = 45f;
    [SerializeField] private Vector3 direction = Vector3.right;

    [SerializeField] private List<GameObject> EnemyClonesList;

    [SerializeField] public LayerMask layermask = 6;
    [SerializeField] public Character character;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindObjectOfType(typeof(Character)) as Character;
        generateEnemies();
    }

    void ifGameOver(){
        if (character.enemyHit){
            speed = 0;
            foreach (var clone in EnemyClonesList.ToArray()) {
                if (clone != null) {
                    clone.transform.Translate(direction * speed * Time.deltaTime);
                }
            }
        }
    }
    void actionMove(GameObject clone) {
        if (!character.enemyHit) {
            clone.transform.Translate(direction * speed * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        ifGameOver();
        foreach (var clone in EnemyClonesList.ToArray()) {
            if (clone != null) {
                if (clone.transform.position.x >= 650) {
                    Destroy(clone);
                    EnemyClonesList.Remove(clone);
                } else {
                    actionMove(clone);
                }
            } else {
                EnemyClonesList.Remove(clone);
            }
        }
    }

    void generateEnemies(){
        StartCoroutine(generateEnemiesRoutine());
        IEnumerator generateEnemiesRoutine() {
            //Debug.Log("Start generating enemies!");

            while(!character.enemyHit) {
                yield return new WaitForSeconds(Random.Range((float) .5, (float) 1.0));
                Vector2 EnemyRandomPosition = new Vector2(-650f, Random.Range(-220, 220f));
                Collider2D CollisionWithReward = Physics2D.OverlapCircle(EnemyRandomPosition, (float) 2.252155, LayerMask.GetMask("RewardLayer"));
                if (!CollisionWithReward) {
                    EnemyClone = Instantiate(EnemyMeaniePrefab, EnemyRandomPosition, Quaternion.identity);
                    EnemyClonesList.Add(EnemyClone);
                }
            }
        }
    }
}
