using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("MainCamera");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            transform.LookAt(playerTransform.transform);    //Look at player at all times
        }
    }
}
