using Photon.Pun;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] private float deltaDestroyTimeIfNotKilled;
    private float _aliveTime;
    private PhotonView _view;
    private ParticleSystem onDestroyEffect;

    private void Start()
    {
        onDestroyEffect = GameObject.Find("EntityDestroyEffect").GetComponent<ParticleSystem>();
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
            _view.RPC("DestroyEnemy", RpcTarget.MasterClient);
        if(other.TryGetComponent<Player>(out Player player))
            _view.RPC("DestroyEnemy", RpcTarget.MasterClient);
    }

    [PunRPC]
    public void DestroyEnemy()
    {
        PhotonNetwork.Destroy(gameObject);
    }

    private void OnDestroy()
    {
        onDestroyEffect.transform.position = transform.position;
        switch (gameObject.name)
        {
            case "Max3D(Clone)":
                onDestroyEffect.startColor = Color.cyan;
                break;
            case "VisualStudio":
                onDestroyEffect.startColor = Color.magenta;
                break;
            case "Idef0(Clone)":
                onDestroyEffect.startColor = Color.red;
                break;
            case "IntellijIdea(Clone)":
                onDestroyEffect.startColor = Color.blue;
                break;
        }
        onDestroyEffect.Play();
    }
}
