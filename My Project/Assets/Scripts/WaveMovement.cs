using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    [SerializeField] float amplitude = 1.0f;
    [SerializeField] float frequency = 1.0f;

    [SerializeField] float waveSpeed = 1.0f;
    private Vector3 initialPosition;

    private void Start()
    {
        {
            initialPosition = transform.position;
        }
    }
    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        float zOffset = Mathf.Sin(Time.time * waveSpeed);
        transform.position = new Vector3(initialPosition.x, initialPosition.y + yOffset, zOffset);
    }
}
