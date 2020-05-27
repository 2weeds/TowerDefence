using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{


    public Transform enemyPrefab;
    public Transform enemyPrefab1;
    public Transform enemyPrefab2;


    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private int waveIndex = 1;
    void Update ()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

    }
    IEnumerator SpawnWave ()
    {


        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2f);
        }
        waveIndex++;


    }
    void SpawnEnemy ()
    {

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation);
        Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);




    }

}
