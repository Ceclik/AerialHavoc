
using Photon.Pun;
using UnityEngine;

public class DeathMenuButtonHandler : MonoBehaviourPunCallbacks
{
    public void OnMainMenuButtonClick()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("MainMenu");
    }
}
