using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject RewardPointPrefab;

    [SerializeField] private GameObject RewardClone;
    [SerializeField] private float speed = 45f;
    [SerializeField] private Vector3 direction = Vector3.right;

    [SerializeField] private List<GameObject> RewardsClonesList;

    [SerializeField] public LayerMask layermask = 3;
    [SerializeField] public Character character;

    void Start(){
        character = GameObject.FindObjectOfType(typeof(Character)) as Character;
        generatePoints();
    }

    void actionMove(GameObject clone) {
        if (!character.enemyHit) {
            clone.transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void ifGameOver(){
        if (character.enemyHit){
            speed = 0;
            foreach (var clone in RewardsClonesList.ToArray()) {
                if (clone != null) {
                    clone.transform.Translate(direction * speed * Time.deltaTime);
                }
            }
        }
    }
    void Update() {
        ifGameOver();
        foreach (var clone in RewardsClonesList.ToArray()) {
            if (clone != null) {
                if (clone.transform.position.x >= 650) {
                    Destroy(clone);
                    RewardsClonesList.Remove(clone);
                } else {
                    actionMove(clone);
                }
            } else {
                RewardsClonesList.Remove(clone);
            }
        }
    }

    void generatePoints(){
        StartCoroutine(generatePointsRoutine());

        IEnumerator generatePointsRoutine() {
            //Debug.Log("Start generating points!");
            while(!character.enemyHit) {
                yield return new WaitForSeconds(Random.Range((float) .75, (float) 1.75));
                Vector2 RewardRandomPosition = new Vector2(-650f, Random.Range(-270f, 270f));
                Collider2D CollisionWithReward = Physics2D.OverlapCircle(RewardRandomPosition, (float) 5.235947, LayerMask.GetMask("EnemyLayer"));
                if (!CollisionWithReward) {
                    RewardClone = Instantiate(RewardPointPrefab, RewardRandomPosition, Quaternion.identity);
                    RewardsClonesList.Add(RewardClone);
                }
            }
        }
    }
}