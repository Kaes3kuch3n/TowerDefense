using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int enemiesAlive;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 20f;
    public float timeBeforeFirstWave = 2f;
    private float countdown;

    public Text waveCountdownText;

    public GameManager gameManager;

    private int waveIndex = 0;

    private void Start()
    {
        countdown = timeBeforeFirstWave;
        enemiesAlive = 0;
    }

    private void Update()
    {
        if (enemiesAlive > 0) return;

        if (waveIndex == waves.Length)
        {
            if (PlayerStats.lives > 0) 
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

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        enemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
