using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpeed : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] float lifetime;
    float customGravity = -8f;
    Rigidbody body;

    public GameObject explosionPrefab;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    void Start()
    {
        body.velocity = transform.forward * speed;
        
        body.useGravity = false;

        Destroy(gameObject, lifetime);                                        //Destroy object after n seconds
    }

    void FixedUpdate()
    {
        body.AddForce(Vector3.up * customGravity, ForceMode.Acceleration);    //Use custom gravity pull
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))                 //Check collition with enemy collider
        {
            var enemy = other.GetComponent<DetectCollision>();
            if (enemy == null) return;

            enemy.TakeDamage(damage);

            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            if (gameObject.CompareTag("Normal"))
            {
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Slow"))    //Special bullet that slows enemy
            {
                var enemySpeed = other.GetComponentInParent<EnemyMovement>();
                enemySpeed.horizontalSpeed /= 2;
                Destroy(gameObject);
            }
            
        }
        
    }
}