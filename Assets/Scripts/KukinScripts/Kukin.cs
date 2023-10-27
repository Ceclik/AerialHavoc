using Photon.Pun;
using UnityEngine;

public class Kukin : MonoBehaviour
{
    public int Health { get; private set; }
    [SerializeField] private int decreaseHealthFromBullet;
    [SerializeField] private AudioSource kukinHurtSound;
    private PhotonView _view;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        Health = 100;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerBullet>(out PlayerBullet bullet))
        {
            _view.RPC("PlayKukinSound", RpcTarget.AllBuffered);
            Health -= decreaseHealthFromBullet;
        }
    }

    [PunRPC]
    public void PlayKukinSound()
    {
        kukinHurtSound.Play();
    }
}
