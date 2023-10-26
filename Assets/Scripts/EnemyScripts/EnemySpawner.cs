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
    [SerializeField] private AudioSource soundTrack;
    public AudioSource BossfightSoundtrack;
    [HideInInspector] public float RunningTime { get; set; }
    [HideInInspector] public int TargetRunningTime { get; set; }
    private GameObject _spawnedEnemy;

    public bool IsBossFight { get; set; }
    private bool _isSoundtrackPlaying;

    private void Update()
    {
        if (game.IsStarted && !IsBossFight && !_isSoundtrackPlaying)
        {
            soundTrack.Play();
            _isSoundtrackPlaying = true;
        }


        RunningTime += Time.deltaTime;
        if (deltaSpawnTime < minimalDeltaSpawnTime)
            deltaSpawnTime = minimalDeltaSpawnTime;
        if (RunningTime > TargetRunningTime && deltaSpawnTime > minimalDeltaSpawnTime)
        {
            TargetRunningTime += howOftenDecreaseDeltaSpawnTime;
            deltaSpawnTime -= deltaSpawnTimeDecreaseValue;
        }
        
        
        if(RunningTime > deltaBossFightTime && PhotonNetwork.IsMasterClient && game.IsStarted && !IsBossFight)
            SpawnKukin();
    }
    private void Awake()
    {
        _isSoundtrackPlaying = false;
        IsBossFight = false;
        TargetRunningTime = howOftenDecreaseDeltaSpawnTime;
        RunningTime = 0;
        StartCoroutine(Spawner());
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
                    new Vector3(10, newYPosition, 0),
                    Quaternion.identity);
                _spawnedEnemy.transform.SetParent(transform);
            }
        }
    }

    private void SpawnKukin()
    {
        _isSoundtrackPlaying = false;
        soundTrack.Stop();
        IsBossFight = true;
        BossfightSoundtrack.Play();
        BossfightSoundtrack.loop = true;
        PhotonNetwork.Instantiate(kukin.name, new Vector3(7.0f, 0.0f, 0.0f), Quaternion.identity);
    }
}
