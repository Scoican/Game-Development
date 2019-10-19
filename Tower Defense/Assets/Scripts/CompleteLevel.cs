using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

    public SceneFaderScript sceneFader;
    public string menuSceneName = "MainMenuScene";
    public string nextLevel = "LevelSelectScene";
    public int nextLevelNumber = 2;

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", nextLevelNumber);
        sceneFader.FadeTo(nextLevel);
    }
}
