using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class ShowDeathMenu : MonoBehaviour
{
   private Player _player;
   private PhotonView _view;
   private GameObject _deathScreen;

   private void Awake()
   {
      _view = GetComponent<PhotonView>();
      _player = GetComponent<Player>();
   }

   private void Update()
   {
      if (!_player.IsAlive && _view.IsMine)
      {
         PhotonNetwork.Destroy(gameObject);
         PhotonNetwork.LeaveRoom();
         PhotonNetwork.LoadLevel("LoseScreen");
      }
   }
}
