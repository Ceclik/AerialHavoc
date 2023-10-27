using Photon.Pun;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] private float deltaDestroyTimeIfNotKilled;
    private float _aliveTime;
    private PhotonView _view;
    private ParticleSystem _enemyGreenDestroyEffect;

    private void Start()
    {
        _enemyGreenDestroyEffect = GameObject.Find("EnemyGreenDestroyEffect").GetComponent<ParticleSystem>();
        _view = GetComponent<PhotonView>();
        _aliveTime = 0;
    }

    private void Update()
    {
        _aliveTime += Time.deltaTime;
        if(_aliveTime >= deltaDestroyTimeIfNotKilled)
            _view.RPC("DestroyEnemy", RpcTarget.MasterClient);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerBullet>(out PlayerBullet bullet))
        {
            _view.RPC("PlayDestroyEffects", RpcTarget.AllBuffered);
            _view.RPC("DestroyEnemy", RpcTarget.MasterClient);
        }

        if(other.TryGetComponent<Player>(out Player player))
            _view.RPC("DestroyEnemy", RpcTarget.MasterClient);
    }

    [PunRPC]
    public void PlayDestroyEffects()
    {
        _enemyGreenDestroyEffect.transform.position = transform.position;
        _enemyGreenDestroyEffect.Play();
    }
    
    [PunRPC]
    public void DestroyEnemy()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
