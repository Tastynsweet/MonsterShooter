using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagment : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void ControlScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GameScene()
    {
        SceneManager.LoadScene(2);
    }

    public void DefeatScene()
    {
        SceneManager.LoadScene(3);
    }



    

    


}
