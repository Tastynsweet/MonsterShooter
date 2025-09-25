using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    [SerializeField] private float trembleAmount;
    [SerializeField] private float trembleSpeed;

    private Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    public void ShakeObject()
    {
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        float elapsed = 0f;
        float duration = 0.3f;

        while (elapsed < duration)
        {
            //Use slightly different values for random offsets
            float offsetX = (Random.value - 0.5f) * 2f * trembleAmount;         //Range from -1 to 1
            float offsetY = (Random.value - 0.5f) * 2f * trembleAmount;
            float offsetZ = (Random.value - 0.5f) * 2f * trembleAmount;

            transform.localPosition = originalPos + new Vector3(offsetX, offsetY, offsetZ);

            elapsed += trembleSpeed;
            yield return new WaitForSeconds(trembleSpeed);
        }

        transform.localPosition = originalPos;
    }
}
