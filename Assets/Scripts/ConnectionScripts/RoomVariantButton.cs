using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomVariantButton : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text roomNameText;
    [SerializeField] private Text amountOfPlayersText;

    public void SetInfo(RoomInfo info)
    {
        roomNameText.text = info.Name;
        amountOfPlayersText.text = $"{info.PlayerCount}/{info.MaxPlayers}";
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomNameText.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Gameplay");
    }
}
