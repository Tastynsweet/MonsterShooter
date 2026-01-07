using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatingHeart : MonoBehaviour
{
    [SerializeField] private float throbAmount;
    [SerializeField] private float throbSpeed;

    [SerializeField] private float maxSpeed = 20.0f;
    private Vector3 originalScale;

    public enum BeatDirection { Uniform, Horizontal, Vertical }
    [SerializeField] private BeatDirection direction = BeatDirection.Uniform;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        float sineValue = Mathf.Sin(Time.time * throbSpeed);
        float scaleOffset = Mathf.Abs(sineValue) * throbAmount;

        Vector3 targetScale = originalScale;

        switch (direction)
        {
            case BeatDirection.Uniform:
                targetScale += new Vector3(scaleOffset, scaleOffset, 0);
                break;
            case BeatDirection.Horizontal:
                targetScale += new Vector3(scaleOffset, 0, 0);
                break;
            case BeatDirection.Vertical:
                targetScale += new Vector3(0, scaleOffset, 0);
                break;
        }

        transform.localScale = targetScale; 
    }

    public void IncreaseHeartRate(float amount)
    {
        throbSpeed += amount;

        if (throbSpeed > maxSpeed) throbSpeed = maxSpeed;
    }
}
