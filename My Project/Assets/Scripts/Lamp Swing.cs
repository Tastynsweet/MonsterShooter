using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwing : MonoBehaviour
{
    [SerializeField] private float swingSpeed = 2.0f;
    [SerializeField] private float swingAngle = 15.0f;

    void Update()
    {
        float currentAngle = swingAngle * Mathf.Sin(Time.time  * swingSpeed);

        transform.localRotation = Quaternion.Euler(0, 0, currentAngle);
    }
}
