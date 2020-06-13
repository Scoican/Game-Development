using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static bool gameIsOver;
    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    public string nextLevel = "MainMenuScene";
    public WaveSpawnerScript waveSpawner;

    private void Start()
    {
        gameIsOver = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameIsOver)
        {
            return;
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
        waveSpawner.enabled = false;
    }

    public void WinLevel()
    {
        gameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}