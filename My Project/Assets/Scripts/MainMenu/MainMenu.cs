using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    const string GAME_SCENE = "Game Scene";
    public void playGame()
    {
        SceneManager.LoadScene(GAME_SCENE, LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }
}
