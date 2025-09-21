using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;
    public float verticalSpeed = -10.0f;
    public float minY = -12f;

    private DetectCollision enemyHealth;

    void Start()
    {
        enemyHealth = GetComponent<DetectCollision>();
    }
    void Update()
    {
        transform.Translate(horizontalSpeed * Time.deltaTime * Vector3.forward);
        if (enemyHealth.healthCounter >- 0 && transform.position.y < minY)
        {
            transform.Translate(Mathf.Abs(verticalSpeed) * Time.deltaTime * Vector3.up);        //object comes into view from below camera
        }
        if (enemyHealth.healthCounter <= 0)                                                     //object translates down out of camera's view
        {
            transform.Translate(Mathf.Abs(verticalSpeed) * Time.deltaTime * Vector3.down);
            horizontalSpeed = 0;
        }
    }

}   
