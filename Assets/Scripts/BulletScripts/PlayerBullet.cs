using Photon.Pun;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float maxAliveTime;
    private float _aliveTime;
    private PhotonView _view;
    private GameObject _bulletsParent;

    private void Awake()
    {
        _bulletsParent = GameObject.Find("PlayersBullets");
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
        Vector3 newPosition = transform.position + transform.up * Time.deltaTime * bulletSpeed;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyMover>(out EnemyMover mover) || other.TryGetComponent<Kukin>(out Kukin dmitro))
            _view.RPC("DestroyBullet", RpcTarget.MasterClient);
    }

    [PunRPC]
    public void DestroyBullet()
    {
        if (_view.IsMine)
            PhotonNetwork.Destroy(gameObject);
    }
}