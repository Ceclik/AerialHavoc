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
      if (_view.IsMine)
      {
         _deathScreen = GameObject.Find("DeathScreenBackground");
         _deathScreen.SetActive(false);
      }
   }

   private void Update()
   {
      if (!_player.IsAlive && _view.IsMine)
      {
         _deathScreen.SetActive(true);
         _player.gameObject.SetActive(false);
      }
   }
}
