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
            _view.RPC("StartNormalSoundTrack", RpcTarget.AllBuffered);
            _view.RPC("DestroyKukin", RpcTarget.MasterClient);
        }
    }

    [PunRPC]
    public void StartNormalSoundTrack()
    {
        _enemySpawner.IsBossFight = false;
        _enemySpawner.BossfightSoundtrack.Stop();
        _enemySpawner.SoundTrack.Play();
        _enemySpawner.IsSoundtrackPlaying = true;
    }

    private void OnDestroy()
    {
        _enemySpawner.IsBossFight = false;
        _enemySpawner.BossfightSoundtrack.Stop();
        _enemySpawner.RunningTime = 0;
        _enemySpawner.deltaSpawnTime = _enemySpawner.StartDeltaSpawnTime;
        _enemySpawner.TargetRunningTime = _enemySpawner.howOftenDecreaseDeltaSpawnTime;
    }

    [PunRPC]
    public void DestroyKukin()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
