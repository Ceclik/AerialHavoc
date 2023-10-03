using System.Collections;
using Photon.Pun;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float deltaSpawnTime;
    private bool _isGameStarted;
    private Transform _playersParent;

    private void Awake()
    {
        _isGameStarted = false;
        _playersParent = GameObject.Find("Players").GetComponent<Transform>();
        if (PhotonNetwork.IsMasterClient)
            StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(deltaSpawnTime);
            if (_playersParent.childCount > 0)
                _isGameStarted = true;
            if (_isGameStarted)
            {
                int newYPosition = Random.Range(-4, 5);
                GameObject spawnedEnemy = PhotonNetwork.Instantiate(enemy.name, new Vector3(7, newYPosition, 0),
                    Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f)));
                spawnedEnemy.GetComponent<Transform>().SetParent(transform);
            }
        }
    }
}
