using Photon.Pun;
using UnityEngine;

public class KukinBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float maxAliveTime;
    private float _aliveTime;
    private PhotonView _view;
    private GameObject _bulletsParent;

    private void Awake()
    {
        _bulletsParent = GameObject.Find("EnemyBullets");
        transform.SetParent(_bulletsParent.transform);
        _view = GetComponent<PhotonView>();
        _aliveTime = 0;
    }

    private void Update()
    {
        _aliveTime += Time.deltaTime;
        if(_aliveTime >= maxAliveTime)
            _view.RPC("DestroyBullet", RpcTarget.MasterClient);
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - bulletSpeed * Time.deltaTime, transform.position.y,
            transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            _view.RPC("DestroyBullet", RpcTarget.MasterClient);
    }

    [PunRPC]
    public void DestroyBullet()
    {
        if (_view.IsMine)
            PhotonNetwork.Destroy(gameObject);
    }
}
