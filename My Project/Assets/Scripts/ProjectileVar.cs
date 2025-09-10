using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpeed : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    private float leftBound = -50.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (transform.position.x < leftBound)    //Destroy bullet if it does hit enemy after a while
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))                 //Check collition with enemy collider
        {
            var enemy = other.GetComponent<DetectCollision>();
            if (enemy == null) return;

            enemy.TakeDamage(damage);

            if (gameObject.CompareTag("Normal"))
            {
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Slow"))    //Special bullet that slows enemy
            {
                var enemySpeed = other.GetComponent<EnemyMovement>();
                enemySpeed.horizontalSpeed /= 2;
                Destroy(gameObject);
            }
            
        }
        
    }
}