using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
   [SerializeField] private GameObject player;
   [SerializeField] private RuntimeAnimatorController tatiana;
   [SerializeField] private RuntimeAnimatorController yurii;
   [SerializeField] private RuntimeAnimatorController emily;

   private void Awake()
   {
      GameObject spawnedPlayer = PhotonNetwork.Instantiate(player.name, player.transform.position, Quaternion.identity);
      if (spawnedPlayer.GetComponent<PhotonView>().IsMine)
         spawnedPlayer.GetComponent<Animator>().runtimeAnimatorController = tatiana;
      else
      {
         if (transform.childCount == 2)
         {
            spawnedPlayer.GetComponent<Animator>().runtimeAnimatorController = yurii;
            spawnedPlayer.GetComponent<Animator>().Play("Yurii");
         }

         if (transform.childCount == 3)
            spawnedPlayer.GetComponent<Animator>().runtimeAnimatorController = emily;
      }
   }
}
