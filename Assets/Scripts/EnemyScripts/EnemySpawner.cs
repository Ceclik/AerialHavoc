using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesVariants;
    [SerializeField] private GameObject kukin;
    [SerializeField] private float deltaSpawnTime;
    [SerializeField] private float deltaSpawnTimeDecreaseValue;
    [SerializeField] public int howOftenDecreaseDeltaSpawnTime;
    [SerializeField] private float minimalDeltaSpawnTime;
    [SerializeField] private int maxAmountOfAliveEnemies;
    [SerializeField] StartGameCondtions game;
    [SerializeField] private float deltaBossFightTime;
    [HideInInspector] public float RunningTime { get; set; }
    [HideInInspector] public int TargetRunningTime { get; set; }
    private GameObject _spawnedEnemy;

    public bool IsBossFight { get; set; }

    private void Update()
    {
        RunningTime += Time.deltaTime;
        if (deltaSpawnTime < minimalDeltaSpawnTime)
            deltaSpawnTime = minimalDeltaSpawnTime;
        if (RunningTime > TargetRunningTime && deltaSpawnTime > minimalDeltaSpawnTime)
        {
            TargetRunningTime += howOftenDecreaseDeltaSpawnTime;
            deltaSpawnTime -= deltaSpawnTimeDecreaseValue;
        }
    }
    private void Awake()
    {
        IsBossFight = false;
        TargetRunningTime = howOftenDecreaseDeltaSpawnTime;
        RunningTime = 0;
        StartCoroutine(Spawner());
        StartCoroutine(BossSpawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(deltaSpawnTime);
            if (transform.childCount <= maxAmountOfAliveEnemies && PhotonNetwork.IsMasterClient && game.IsStarted && !IsBossFight)
            {
                int newYPosition = Random.Range(-4, 5);
                int enemyChoice = Random.Range(0, enemiesVariants.Count);
                _spawnedEnemy = PhotonNetwork.Instantiate(enemiesVariants[enemyChoice].name,
                    new Vector3(7, newYPosition, 0),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f)));
                _spawnedEnemy.transform.SetParent(transform);
            }
        }
    }

    private IEnumerator BossSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(deltaBossFightTime);
            if (PhotonNetwork.IsMasterClient && game.IsStarted && !IsBossFight)
            {
                IsBossFight = true;
                PhotonNetwork.Instantiate(kukin.name, new Vector3(7.0f, 0.0f, 0.0f), Quaternion.identity);
            }
        }
    }
}
