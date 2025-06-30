using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [SerializeField] int healthCounter = 10;

    public void TakeDamage(int damage)
    {
        healthCounter -= damage;
        Debug.Log("Enemy took: " + damage + " damage");

        if (healthCounter <= 0) {
            Destroy(gameObject);
            Debug.Log("Enemy destroyed");
        }
    }
}
    