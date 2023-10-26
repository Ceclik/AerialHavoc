using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> bonusVariants;
    [SerializeField] private float deltaSpawnTime;
    [SerializeField] private int maxAmountOfSpawnedBonuses;
    [SerializeField] private StartGameCondtions game;

    private void Awake()
    {
        StartCoroutine(Spawner());
    }

    public IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(deltaSpawnTime);
            if(PhotonNetwork.IsMasterClient && game.IsStarted && transform.childCount <= maxAmountOfSpawnedBonuses)
            {
                int indexOfBonusVariant = Random.Range(0, bonusVariants.Count);
                int newYPosition = Random.Range(-4, 5);
                GameObject spawnedBonus = PhotonNetwork.Instantiate(bonusVariants[indexOfBonusVariant].name,
                    new Vector3(10, newYPosition, 0), Quaternion.identity);
                spawnedBonus.transform.SetParent(transform);
            }
        }
    }
}
