using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    SceneManagment defeatGameScene;
    void Update()
    {
        if (health <= 0)
        {
            defeatGameScene.DefeatScene();
        }
    }

    public void takeDamage()
    {
        health--;
        Debug.Log("Player Damaged");
        if (health <= 0)
        {
            Debug.Log("You Lose");
        }
    }
}
