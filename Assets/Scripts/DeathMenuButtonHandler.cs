using Photon.Pun;
using UnityEngine;

public class DeathMenuButtonHandler : MonoBehaviourPunCallbacks
{
    public void OnMainMenuButtonClick()
    {
        PhotonNetwork.LoadLevel("MainMenu");
    }
}
