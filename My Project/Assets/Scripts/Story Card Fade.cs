using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryCardFade : MonoBehaviour
{
    public Image storyDisplay;
    public CanvasGroup cardCanvas;

    public Sprite[] storyImages;

    public float fadeSpeed = 1.0f;
    public float waitBeforeFadeOut = 0.5f;

    public string sceneToLoad = "Game Scene";
    void Start()
    {
        cardCanvas.alpha = 0;
        StartCoroutine(PlayStory());
        
    }

    IEnumerator PlayStory()
    {
        yield return new WaitForSeconds(1.5f);
        
        foreach (Sprite img in storyImages)
        {
            storyDisplay.sprite = img;

            yield return Fade(0, 1);

            yield return null;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space));

            yield return Fade(1,0);

            yield return new WaitForSeconds(waitBeforeFadeOut);
        }

        SceneManagment sceneManager = FindFirstObjectByType<SceneManagment>();

        if (sceneManager != null)
        {
            sceneManager.LoadLevel(sceneToLoad);
        }
    }

    IEnumerator Fade(float start, float end)
    {
        float counter = 0f;
        while (counter < fadeSpeed)
        {
            counter += Time.deltaTime;
            cardCanvas.alpha = Mathf.Lerp(start, end, counter / fadeSpeed);
            yield return null;
        }

        cardCanvas.alpha = end;
    }

}
