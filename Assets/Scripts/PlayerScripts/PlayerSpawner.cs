using System;
using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
   [SerializeField] private GameObject player;

   private void Awake()
   {
      GameObject spawnedPlayer = PhotonNetwork.Instantiate(player.name, new Vector3(-6.5f, 0, 0), Quaternion.Euler(new Vector3(0.0f, 0.0f, -90.0f)));
      spawnedPlayer.transform.SetParent(transform);
   }
}
