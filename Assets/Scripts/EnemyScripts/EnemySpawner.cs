using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesVariants;
    [SerializeField] private GameObject kukin;
    [SerializeField] public float deltaSpawnTime;
    public float StartDeltaSpawnTime { get; private set; }
    [SerializeField] private float deltaSpawnTimeDecreaseValue;
    public int howOftenDecreaseDeltaSpawnTime;
    [SerializeField] private float minimalDeltaSpawnTime;
    [SerializeField] private int maxAmountOfAliveEnemies;
    [SerializeField] StartGameCondtions game;
    [SerializeField] private float deltaBossFightTime;
    [SerializeField] public AudioSource SoundTrack;
    public AudioSource BossfightSoundtrack;
    public float RunningTime { get; set; }
    public int TargetRunningTime { get; set; }
    private GameObject _spawnedEnemy;
    private PhotonView _view;

    public bool IsBossFight { get; set; }
    public bool IsSoundtrackPlaying { get; set; }

    private void Update()
    {
        if (game.IsStarted && !IsBossFight && !IsSoundtrackPlaying)
        {
            SoundTrack.Play();
            IsSoundtrackPlaying = true;
        }


        if (game.IsStarted)
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

        if(RunningTime > deltaBossFightTime && PhotonNetwork.IsMasterClient && game.IsStarted && !IsBossFight)
            SpawnKukin();
    }
    private void Awake()
    {
        _view = GetComponent<PhotonView>();
        IsSoundtrackPlaying = false;
        IsBossFight = false;
        StartDeltaSpawnTime = deltaSpawnTime;
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
        _view.RPC("StartBossFightSoundtrack", RpcTarget.AllBuffered);
        PhotonNetwork.Instantiate(kukin.name, new Vector3(7.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    [PunRPC]
    public void StartBossFightSoundtrack()
    {
        IsBossFight = true;
        IsSoundtrackPlaying = false;
        SoundTrack.Stop();
        BossfightSoundtrack.Play();
        BossfightSoundtrack.loop = true;
    }
}
