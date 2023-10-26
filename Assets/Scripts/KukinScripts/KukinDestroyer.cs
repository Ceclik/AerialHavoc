using Photon.Pun;
using UnityEngine;

public class KukinDestroyer : MonoBehaviour
{
    private Kukin _dmitro;
    private PhotonView _view;
    private EnemySpawner _enemySpawner;

    private void Start()
    {
        _enemySpawner = GameObject.Find("Enemies").GetComponent<EnemySpawner>();
        _dmitro = GetComponent<Kukin>();
        _view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_dmitro.Health <= 0)
        {
            _enemySpawner.BossfightSoundtrack.Stop();
            _enemySpawner.RunningTime = 0;
            _enemySpawner.TargetRunningTime = _enemySpawner.howOftenDecreaseDeltaSpawnTime;
            _enemySpawner.IsBossFight = false;
            _view.RPC("DestroyKukin", RpcTarget.MasterClient);
        }
    }

    [PunRPC]
    public void DestroyKukin()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
