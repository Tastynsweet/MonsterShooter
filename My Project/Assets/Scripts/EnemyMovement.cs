using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float horizontalSpeed;
    public float verticalSpeed = -10.0f;
    public float minY = -12f;

    [SerializeField] private DetectCollision enemyHealth;

    void Awake()
    {
        horizontalSpeed = Random.Range(-9, -12);
    }

    void Update()
    {
        transform.Translate(horizontalSpeed * Time.deltaTime * Vector3.left);
        if (enemyHealth.healthCounter >- 0 && transform.position.y < minY)
        {
            transform.Translate(Mathf.Abs(verticalSpeed) * Time.deltaTime * Vector3.up);        //object comes into view from below camera
        }
        if (enemyHealth.healthCounter <= 0)                                                     //object translates down out of camera's view
        {
            transform.Translate(Mathf.Abs(verticalSpeed) * Time.deltaTime * Vector3.down);
            horizontalSpeed = 0;
            if (enemyHealth.pastThreshold == true)
            {
                Destroy(gameObject);
                Debug.Log("Enemy destroyed");
            }
        }
    }

}   
