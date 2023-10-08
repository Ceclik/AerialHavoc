using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
   [SerializeField] private GameObject player;
   public bool IsGameStarted { get; private set; }

   private void Start()
   {
      IsGameStarted = false;
      GameObject spawnedPlayer = PhotonNetwork.Instantiate(player.name, new Vector3(-6.5f, 0, 0), Quaternion.Euler(new Vector3(0.0f, 0.0f, -90.0f)));
      if (spawnedPlayer.GetComponent<PhotonView>().IsMine)
         spawnedPlayer.GetComponent<SpriteRenderer>().color = Color.green;
   }
}
