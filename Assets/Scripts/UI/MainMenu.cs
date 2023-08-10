using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OptionsMenu()
    {
        Debug.Log("Options menu in progress");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
