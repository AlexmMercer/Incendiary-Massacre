using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameObject StartGameButton;
    [SerializeField] GameObject QuitGameButton;
    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    public void ClickPlaySound()
    {
        StartGameButton.GetComponent<AudioSource>().Play();
    }

    public void ClickQuitSound()
    {
        QuitGameButton.GetComponent<AudioSource>().Play();
    }
}
