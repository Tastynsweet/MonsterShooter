using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagment : MonoBehaviour
{
    private UIFade fadeUI;

    public void StartScene()
    {
        StartCoroutine(ChangeLevelCo("Start Menu"));
    }

    public void GameScene()
    {
        StartCoroutine(ChangeLevelCo("Game Scene"));
    }

    public void DefeatScene()
    {
        StartCoroutine(ChangeLevelCo("Defeat Scene"));
    }

    private IEnumerator ChangeLevelCo(string levelName)
    {
        GetFadeUI().DoFadeOut();

        yield return GetFadeUI().changeAlphaCo;

        SceneManager.LoadScene(levelName);
    }

    private UIFade GetFadeUI()
    {
        if (fadeUI == null)
        {
            fadeUI = FindFirstObjectByType<UIFade>();
        }
        return fadeUI;
    }



}
