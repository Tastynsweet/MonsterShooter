using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] float time;
    private float timer = 100.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
       if (timer >= time)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                timer = 0;
            }
        }
    }
}
