using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
   [SerializeField] private GameObject player;

   private void Awake()
   {
      PhotonNetwork.Instantiate(player.name, player.transform.position, Quaternion.identity);
   }
}
