using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;
    public float verticalSpeed = -10.0f;
    public float minY = -12f;

    void Update()
    {
        transform.Translate(Vector3.forward * horizontalSpeed * Time.deltaTime);
        if (transform.position.y < minY)
        {
            transform.Translate(Vector3.up * Mathf.Abs(verticalSpeed) * Time.deltaTime);
        }
    }

}
