using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public string levelToLoad = "TowerDefenseScene";

    public SceneFaderScript sceneFader;
     
    public void Play () {
        sceneFader.FadeTo(levelToLoad);
	}
	
	// Update is called once per frame
	public void  Quit() {
        Application.Quit();
    }
}
