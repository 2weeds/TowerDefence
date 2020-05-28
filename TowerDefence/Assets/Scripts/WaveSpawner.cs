using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{


    public Transform enemyPrefab;
    public Transform enemyPrefab1;
    public Transform enemyPrefab2;


    public Transform spawnPoint;
    public string enemyTag;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    public static int waveIndex = 0;
    void Update ()
    {
        if (!IfEnemyAlive())
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }
    IEnumerator SpawnWave ()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
        
    }
    void SpawnEnemy ()
    {
        if (waveIndex <= 5)
        {
            Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
        }
        else if (waveIndex>5||waveIndex<=10)
        {

            Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab1, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
        }
        
    }
    public int countWaves()
    {
        return waveIndex;
    }
    public bool IfEnemyAlive()
    {
        bool tmp = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                tmp = true;
                break;
            }
        }
        return tmp;
    }

}
