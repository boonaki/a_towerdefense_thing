using UnityEngine;
using System.Collections;

public class Wave_spawn : MonoBehaviour
{
    public Transform enemyprefab;
    public Transform spawnPoint;

    public float time_between_waves = 5f;
    private float countdown = 2f;
    private int numofenemy;
    private int waveNumber = 1;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = time_between_waves;
            // Debug.Log("Wave spawning");
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.2f);

        }
        // Debug.Log("wave spawned");
        waveNumber++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyprefab, spawnPoint.position, spawnPoint.rotation);
    }
}
