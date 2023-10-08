using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomCreator : MonoBehaviourPunCallbacks
{
   [SerializeField] private InputField roomNameField;

   public void OnCreateButtonClick()
   {
      RoomOptions roomOptions = new RoomOptions();
      roomOptions.MaxPlayers = 4;
      PhotonNetwork.CreateRoom(roomNameField.text, roomOptions);
   }

   public override void OnCreatedRoom()
   {
      PhotonNetwork.LoadLevel("Gameplay");  
   }
}
