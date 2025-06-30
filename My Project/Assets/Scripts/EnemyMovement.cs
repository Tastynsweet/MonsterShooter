using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 15.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerHealth>();
        if (player == null) return;

        player.takeDamage();
        Destroy(gameObject);
    }

}
