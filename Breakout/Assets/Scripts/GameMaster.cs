using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one GameMaster in scene!");
            return;
        }
        instance = this;
    }

    public GameObject startGameUI;
    public GameObject pausedGameUI;
    public GameObject endGamedUI;


    public static bool gameStarted;
    public static bool gamePaused;
    public static bool gameFinished;

    // Use this for initialization
    void Start()
    {
        gameStarted = false;
        gamePaused = false;
        gameFinished = false;
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFinished)
        {
            return;
        }
        if (Input.GetKeyDown("space"))
        {
            if (gameStarted == false)
            {
                StartGame();
            }
            else
                PauseGame();
        }

    }

    void StartGame()
    {
        Time.timeScale = 1f;
        startGameUI.SetActive(false);
        gameStarted = true;
    }

    public void PauseGame()
    {
        if (gamePaused)
        {
            Time.timeScale = 1f;
            pausedGameUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pausedGameUI.SetActive(true);
        }
        gamePaused = !gamePaused;

    }

    public void EndGame()
    {
        Time.timeScale = 0f;
        gameFinished = true;
        endGamedUI.SetActive(true);
    }
}
