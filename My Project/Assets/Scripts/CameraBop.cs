using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBop : MonoBehaviour
{
    [SerializeField] private float bopAmount;
    [SerializeField] private float bopSpeed;
    [SerializeField] private float lerpSpeed;

    private Vector3 originalPos;
    void Start()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        float bop = Mathf.Sin(Time.time * bopSpeed * Mathf.PI * 2f) * bopAmount;                                              //Calculate Y offset
        Vector3 bopOffset = new Vector3(0, bop, 0);

        transform.position = Vector3.Lerp(transform.position, originalPos + bopOffset, Time.deltaTime * lerpSpeed);           //Smooth transition
    }
}