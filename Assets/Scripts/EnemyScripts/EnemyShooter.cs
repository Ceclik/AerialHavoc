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
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(enemyBullet.name, transform.position, firstBulletRotation);
                PhotonNetwork.Instantiate(enemyBullet.name, transform.position, secondBulletRotation);
            }
        }
    }
}
