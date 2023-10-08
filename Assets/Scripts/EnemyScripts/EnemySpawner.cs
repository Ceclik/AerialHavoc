using System.Collections;
using Photon.Pun;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float deltaSpawnTime;
    [SerializeField] private float deltaSpawnTimeDecreaseValue;
    [SerializeField] private int howOftenDecreaseDeltaSpawnTime;
    [SerializeField] private float minimalDeltaSpawnTime;
    [SerializeField] private int maxAmountOfAliveEnemies;
    [SerializeField] StartGameCondtions game;
    private float _runningTime;
    private int _targetRunningTime;

    private void Update()
    {
        _runningTime += Time.deltaTime;
        if (deltaSpawnTime < minimalDeltaSpawnTime)
            deltaSpawnTime = minimalDeltaSpawnTime;
        if (_runningTime > _targetRunningTime && deltaSpawnTime > minimalDeltaSpawnTime)
        {
            _targetRunningTime += howOftenDecreaseDeltaSpawnTime;
            deltaSpawnTime -= deltaSpawnTimeDecreaseValue;
        }
    }
    private void Awake()
    {
        _targetRunningTime = howOftenDecreaseDeltaSpawnTime;
        _runningTime = 0;
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(deltaSpawnTime);
            if (transform.childCount <= maxAmountOfAliveEnemies && PhotonNetwork.IsMasterClient && game.IsStarted)
            {
                int newYPosition = Random.Range(-4, 5);
                GameObject spawnedEnemy = PhotonNetwork.Instantiate(enemy.name, new Vector3(7, newYPosition, 0),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f)));
                spawnedEnemy.transform.SetParent(transform);
            }
        }
    }
}
