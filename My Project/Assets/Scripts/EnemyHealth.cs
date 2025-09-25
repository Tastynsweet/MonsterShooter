using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int healthCounter;
    private Collider enemyCollider;
    private bool isDead = false;
    public bool pastThreshold = false;

    private ObjectShake shakeEnemy;
    

    void Awake()
    {
        healthCounter = Random.Range(10, 15);
    }

    void Start()
    {
        enemyCollider = GetComponent<Collider>();
        shakeEnemy = GetComponent<ObjectShake>();
    }

    void Update()
    {
        if (isDead)
        {
            shakeEnemy.ShakeObject();
            enemyCollider.enabled = false;                  //Remove collision

            if (transform.position.y < -100f)               //Delete object once out of view
            {
                pastThreshold = true;
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        healthCounter -= damage;
        Debug.Log("Enemy took: " + damage + " damage");

        if (healthCounter <= 0) 
        {
            isDead = true;
            ScoreManagement.instance.addScore();
        }
    }
}
    