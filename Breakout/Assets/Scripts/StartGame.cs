using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
	public Button StartGameButton;
	public Button SinglePlayerButton;
	public Button MultiplayerPlayerButton;
	public Button ExitGameButton;

	public void SinglePlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void TwoPlayer()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}

	public void OnStartGamePressed()
	{
		StartGameButton.gameObject.SetActive(false);
		ExitGameButton.gameObject.SetActive(false);
		SinglePlayerButton.gameObject.SetActive(true);
		MultiplayerPlayerButton.gameObject.SetActive(true);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
