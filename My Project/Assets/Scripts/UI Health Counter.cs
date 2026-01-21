using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthCounter : MonoBehaviour
{
    public Sprite[] healthCounter;
    private Image currentCounter;

    public float fadeSpeed = 1.0f;

    private int currentIndex;

    void Start()
    {
        currentCounter = GetComponent<Image>();
        currentCounter.color = new Color(1, 1, 1, 0);

    }
    public void changeSpriteOnDamage()
    {
        if (currentIndex < healthCounter.Length)
        {

            StopAllCoroutines();
            StartCoroutine(Fade(0f, 1f));

            if (currentCounter != null)
            {
                currentCounter.sprite = healthCounter[currentIndex];
            }

            currentIndex++;
        }
    }

    IEnumerator Fade(float start, float end)
    {
        float counter = 0f;

        Color currentColor = currentCounter.color;

        while (counter < fadeSpeed)
        {
            counter += Time.deltaTime;
            float alphaValue = Mathf.Lerp(start, end, counter / fadeSpeed);

            currentCounter.color = new Color(currentColor.r, currentColor.g, currentColor.b, alphaValue);

            yield return null;
        }

        currentCounter.color = new Color(currentColor.r, currentColor.g, currentColor.b, end);
    }
}
