using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    const string GAME_SCENE = "Game Scene";

    [SerializeField] private GameObject menuPop;
    [SerializeField] private GameObject creditPop;

    [SerializeField] private GameObject backgroundDim;

    private GameObject activePanel;
    

    private void Update()
    {
        if (activePanel != null && Input.GetKeyDown(KeyCode.Escape))
        {
            ClosePanel();
        }
    }
    public void playGame()
    {
        SceneManager.LoadScene(GAME_SCENE, LoadSceneMode.Single);
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
}
