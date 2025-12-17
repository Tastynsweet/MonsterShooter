using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//AlexDev FadeIn Code
public class UIFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float fadeDuration = 1.5f;
    public Coroutine changeAlphaCo { get; private set; }

    private void Start()
    {
        DoFadeIn();
    }

    public void DoFadeIn()
    {
        FadeEffect(0);
    }

    public void DoFadeOut()
    {
        FadeEffect(1);
    }

    private void FadeEffect(float targetAlpha)
    {
        if(changeAlphaCo != null)
        {
            StopCoroutine(changeAlphaCo);
        }

        changeAlphaCo = StartCoroutine(ChangeAlphaCo(targetAlpha));
    }

    private IEnumerator ChangeAlphaCo(float targetAlpha)
    {
        float timePassed = 0;
        float startAlpha = canvasGroup.alpha;

        if (targetAlpha > 0)
        {
            canvasGroup.blocksRaycasts = true;
        }

        while (timePassed < fadeDuration)
        {
            timePassed = timePassed + Time.deltaTime;

            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, timePassed / fadeDuration);

            yield return null;
        }

        canvasGroup.alpha = targetAlpha;

        if (targetAlpha == 0)
        {
            canvasGroup.blocksRaycasts = false;
        }
    }
}
