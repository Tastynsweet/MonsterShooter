using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    const string GAME_SCENE = "Story Scene";

    [SerializeField] private GameObject menuPop;
    [SerializeField] private GameObject creditPop;

    [SerializeField] private GameObject backgroundDim;

    private GameObject activePanel;
    private UIFade fadeUI;
    

    private void Update()
    {
        if (activePanel != null && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Escape)))
        {
            ClosePanel();
        }
    }
    public void playGame()
    {
        StartCoroutine(ChangeLevelCo(GAME_SCENE));
    }

    public void quitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

    public void OpenControls()
    {
        OpenPanel(menuPop);
    }
    
    public void OpenCredits()
    {
        OpenPanel(creditPop);
    }

    private void OpenPanel(GameObject panel)
    {
        if (activePanel != null)
        {
            activePanel.SetActive(false);
        }

        panel.SetActive(true);
        activePanel = panel;

        if (backgroundDim != null)
        {
            backgroundDim.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        if (activePanel != null)
        {
            activePanel.SetActive(false);
            activePanel = null;
        }

        if (backgroundDim != null)
        {   
            backgroundDim.SetActive(false);
        }
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
