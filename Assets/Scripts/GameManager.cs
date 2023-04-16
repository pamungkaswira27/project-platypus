using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isPlayerDie;
    public bool isGameOver;

    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform spawnPosition;

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        EventManager.OnPlayerDied += SpawnPlayer;
    }

    void OnDisable()
    {
        EventManager.OnPlayerDied -= SpawnPlayer;
    }

    void SpawnPlayer()
    {
        StartCoroutine(SpawnPlayerCoroutine());
    }

    IEnumerator SpawnPlayerCoroutine()
    {
        yield return new WaitForSeconds(1f);

        Instantiate(playerPrefab, spawnPosition.position, Quaternion.identity);
        isPlayerDie = false;
        EventManager.Fire_OnPlayerSpawn();
    }
}
