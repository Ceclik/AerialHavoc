using Photon.Pun;
using UnityEngine;

public class ConnectorToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.LoadLevel("MainMenu");
        PhotonNetwork.JoinLobby();
    }
}
