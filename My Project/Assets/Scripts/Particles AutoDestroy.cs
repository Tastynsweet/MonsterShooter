using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesAutoDestroy : MonoBehaviour
{
    [SerializeField] private float lifetime = 2.0f;

    void Start()
    {
        Destroy(gameObject, lifetime);    
    }

}
