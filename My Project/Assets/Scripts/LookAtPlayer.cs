using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform playerTransform;
    private DetectCollision enemyH;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("MainCamera");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        enemyH = GetComponent<DetectCollision>();
    }

    void Update()
    {
        if (playerTransform != null && StillHealthy())
        {
            transform.LookAt(playerTransform.transform);    //Look at player at all times
        }
    }

    private bool StillHealthy()
    {
        if (enemyH.healthCounter <= 0)
        {
            return false;
        }
        return true;
    }
}
