using UnityEngine;
using System.Collections;

public class SpawnerControl : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject SpawnPoint;

    public Wave[] waves;

    private int currentWaveIndex = 0;

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            countdown = waves[currentWaveIndex].timeToNextWave;
            StartCoroutine(SpawnWave());
        }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
        {
            Instantiate(waves[currentWaveIndex].enemies[i], SpawnPoint.transform);
            yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
        }
    }
}

[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;

    
}