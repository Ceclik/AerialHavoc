using Photon.Pun;
using UnityEngine;

public class BonusDestroyer : MonoBehaviour
{
    [SerializeField] private float deltaDestroyTimeIfNotKilled;
    private float _aliveTime;
    private PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        _aliveTime = 0;
    }

    private void Update()
    {
        _aliveTime += Time.deltaTime;
        if(_aliveTime >= deltaDestroyTimeIfNotKilled)
            _view.RPC("DestroyBonus", RpcTarget.MasterClient);
    }

    public void DestroyWhenHit()
    {
        _view.RPC("DestroyBonus", RpcTarget.MasterClient);
    }

    [PunRPC]
    public void DestroyBonus()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
