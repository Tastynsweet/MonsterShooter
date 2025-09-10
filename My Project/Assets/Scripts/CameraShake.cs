using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 1.0f;
    public AnimationCurve curve;

    private Vector3 originalPos;

    private void Awake()
    {
        originalPos = transform.position;
    }

    public IEnumerator ScreenShake()

    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            transform.position = originalPos + Random.insideUnitSphere * strength;      //Camera moves randomly with given strength
            yield return null;
        }

        transform.position = originalPos;
    }

    public void UpdateOriginalPosition(Vector3 pos)
    {
        originalPos = pos;
    }
}
