using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject DeathScreen;
    [SerializeField] RedLineScript redLine;
    [SerializeField] BarrelsWaveManager barrelsWaveManager;
    [SerializeField] WaveManager waveManager;
    private bool gameOver;

    private void Start()
    {
        gameOver = false;
        DeathScreen.SetActive(false);
    }

    private void Update()
    {
        switchGameState();
        isGameOver();
    }

    void isGameOver()
    {
        switch(gameOver)
        {
            case true:
                turnOnDeath();
                break;
            case false:
                break;
        }
    }

    private void switchGameState()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == 0 || redLine.ProtestersAchievedNum >= 3)
        {
            gameOver = true;
        }
    }

    private void turnOnDeath()
    {
        DeathScreen.SetActive(true);
        GetComponent<TimerScript>().StopTimer();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
