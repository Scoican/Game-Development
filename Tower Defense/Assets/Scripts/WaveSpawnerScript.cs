using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WaveSpawnerScript : MonoBehaviour {

    public static int EnemiesAlive = 0;
    public WaveScript[] waves;
    public GameManagerScript gameManager;

    public Transform spawnPoint;
    public Text waveCountdownText;

    public int waveIndex;
    public float timeBetweenWaves = 20f;

    private float countdown = 2f;

	// Use this for initialization
	void Start () {
        EnemiesAlive = 0;
    }

    // Update is called once per frame
    void Update () {
        if (EnemiesAlive > 0)
        {
            return;
        }
         
        if (waveIndex == waves.Length && PlayerStats.Lives>0)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        WaveScript wave = waves[waveIndex];
        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }


    private int GetNumberOfEnemies()
    {
        return Random.Range(PlayerStats.Rounds+1, 2 * PlayerStats.Rounds+1);
    }
}
