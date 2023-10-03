using UnityEngine;

[RequireComponent(typeof(Player))]
public class ShowDeathMenu : MonoBehaviour
{
   private Player _player;
   private GameObject _deathScreen;

   private void Awake()
   {
      _player = GetComponent<Player>();
      _deathScreen = GameObject.Find("DeathScreenBackground");
      _deathScreen.SetActive(false);
   }

   private void Update()
   {
      if (!_player.IsAlive && _player.View.IsMine)
      {
         _deathScreen.SetActive(true);
         _player.gameObject.SetActive(false);
      }
   }
}
