using System.Collections;
using Photon.Pun;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float shootingDeltaTime;
    private Quaternion firstBulletRotation;
    private Quaternion secondBulletRotation;
    private PhotonView _view;
    private void Start()
    {
        firstBulletRotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);
        secondBulletRotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
        _view = GetComponent<PhotonView>();
        StartCoroutine(Shooter());
    }

    private IEnumerator Shooter()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingDeltaTime);
            _view.RPC("SpawnEnemyBullet", RpcTarget.MasterClient, transform.position, firstBulletRotation);
            _view.RPC("SpawnEnemyBullet", RpcTarget.MasterClient, transform.position, secondBulletRotation);
        }
    }

    [PunRPC]
    public void SpawnEnemyBullet(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        PhotonNetwork.Instantiate(enemyBullet.name, spawnPosition, spawnRotation);
    }
}
