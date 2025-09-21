using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public int healthCounter = 10;
    private Collider enemyCollider;
    private bool isDead = false;

    void Start()
    {
        enemyCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if (isDead)
        {
            enemyCollider.enabled = false;                  //Remove collision
            if (transform.position.y < -100f)               //Delete object once out of view
            {
                Destroy(gameObject);
                Debug.Log("Enemy destroyed");
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
    