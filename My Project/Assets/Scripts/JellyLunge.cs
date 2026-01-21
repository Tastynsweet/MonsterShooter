using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyLunge : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float tilt = 3.0f;
    [SerializeField] private float squash = 0.1f;

    private Vector3 originalScale;
    private Quaternion initialRotation;

    void Start()
    {
        originalScale = transform.localScale;
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float wave = Mathf.Sin(Time.time * speed);
        float rotZ = wave * tilt;
        transform.localRotation = initialRotation * Quaternion.Euler(0, 0, -rotZ);

        float stretch = Mathf.Abs(wave);

        float newY = originalScale.y + (stretch * squash);
        float newX = originalScale.x - (stretch * squash * 0.5f);

        transform.localScale = new Vector3(newX, newY, originalScale.z);
    }
}
