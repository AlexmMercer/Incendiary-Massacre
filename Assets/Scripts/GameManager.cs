using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject DeathScreen;
    [SerializeField] GameObject ReplayButton;
    [SerializeField] GameObject MainMenubutton;
    [SerializeField] RedLineScript redLine;
    [SerializeField] BarrelsWaveManager barrelsWaveManager;
    [SerializeField] WaveManager waveManager;
    private bool gameOver;
    private int score = 0;
    public int Score { get { return score; } }

    private int deadSoldiers = 0;
    public int DeadSoldiers {  get { return deadSoldiers; } }

    private int deadTerrorists = 0;
    public int DeadTerrorists { get {  return deadTerrorists; } set { deadTerrorists = value; } }

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
        DeathScreen.transform.Find("StatisticsPanel").transform.Find("TimeText").GetComponent<TextMeshProUGUI>().text = $"Time: {GetComponent<TimerScript>().timerText.text}";
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

    public void ClickReplaySound()
    {
        ReplayButton.GetComponent<AudioSource>().Play();
    }

    public void ClickMainMenuComeBackSound()
    {
        MainMenubutton.GetComponent<AudioSource>().Play();
    }
}
