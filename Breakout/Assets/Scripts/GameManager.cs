using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;
	public GameObject InGameUI;
	public Text ScoreUI;
	public int NumberOfBalls;
	public int NumberOfBricks;
	public bool isGameFinished;
	public bool hasGameStarted;

	private void Start()
	{
		NumberOfBalls = 1;
		NumberOfBricks = (12 * 5);
		isGameFinished = false;
		hasGameStarted = false;
	}
	// Update is called once per frame
	void Update()
	{

	}

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in the scene!");
		}
		instance = this;
	}

	public void DecrementNumberOfBalls()
	{
		NumberOfBalls--;
		CheckGameStat();
	}

	public void DecrementNumberOfBricks()
	{
		NumberOfBricks--;
		Debug.Log(NumberOfBricks);
		ScoreUI.text = $"Score: {((12 * 5) - NumberOfBricks) * 10}";
		CheckGameStat();
	}

	private void CheckGameStat()
	{
		if (NumberOfBalls > 0 && NumberOfBricks > 0)
		{
			return;
		}
		else
		{
			InGameUI.SetActive(true);
			isGameFinished = true;
		}
	}

	public void OnRetryButtonDown()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void OnMainMenuButtonDown()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
