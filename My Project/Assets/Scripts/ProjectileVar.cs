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

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<DetectCollision>();
            if (enemy == null) return;

            enemy.TakeDamage(damage);

            if (gameObject.CompareTag("Normal"))
            {
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Slow"))
            {
                var enemySpeed = other.GetComponent<EnemyMovement>();
                enemySpeed.speed /= 2;
                Destroy(gameObject);
            }
            
        }
        
    }
}