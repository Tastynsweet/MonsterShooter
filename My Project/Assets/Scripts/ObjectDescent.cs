using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDescent : MonoBehaviour
{
    GameObject backgroundObject;
    [SerializeField] private float descentSpeed;
    private float descentDelay = 2.0f;
    private float timer = 0.0f;

    private ObjectShake shake;

    private void Start()
    {
        shake = GetComponentInChildren<ObjectShake>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= descentDelay)
        {
            transform.Translate(Mathf.Abs(descentSpeed) * Time.deltaTime * Vector3.down);       //Descend down
            
            if (shake != null )
            {
                shake.ShakeObject();
            }
        }

        if (transform.position.y < -700f)                                                   //Delete object once out of view
        {
            Destroy(gameObject);
            Debug.Log("Background Enemy destroyed");
        }
    }
}
