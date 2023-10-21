using System.Collections;
using Photon.Pun;
using UnityEngine;

public class KukinShooter : MonoBehaviour
{
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private float shootingDeltaTime;
    private PhotonView _view;
    private void Start()
    {
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
                PhotonNetwork.Instantiate(enemyBullet.name, transform.position, Quaternion.identity);
            }
        }
    }
}
