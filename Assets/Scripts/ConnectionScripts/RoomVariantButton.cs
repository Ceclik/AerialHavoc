using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomVariantButton : MonoBehaviourPunCallbacks
{

    private Text[] texsts;
    private Text amountOfPlayersText;
    private Text roomNameText;

    private void Awake()
    {
        texsts = GetComponentsInChildren<Text>();
        amountOfPlayersText = texsts[1];
        roomNameText = texsts[0];
    }

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
