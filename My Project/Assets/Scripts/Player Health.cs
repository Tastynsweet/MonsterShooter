using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    private HashSet<GameObject> enemiesReached = new();   //Keep track of repeated enemies
    public SceneManagment defeatGameScene;

    public void PlayerTakeDamage()
    {
        health--;
        ScoreManagement.instance.removeHealth();
        Debug.Log("Player Damaged. New health is " + health);

        if (health <= 0)
        {
            defeatGameScene.DefeatScene();
            Debug.Log("You Lose");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!enemiesReached.Contains(other.GameObject()))
            {
                enemiesReached.Add(other.GameObject());
                Debug.Log("Added enemies to hash");

                PlayerTakeDamage();
                Destroy(other.gameObject);
            }
            
        }
    }
}
