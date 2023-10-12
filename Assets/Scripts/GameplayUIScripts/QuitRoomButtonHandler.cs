using Photon.Pun;

public class QuitRoomButtonHandler : MonoBehaviourPunCallbacks
{
   public void OnPauseButtonClick()
   {
      PhotonNetwork.LeaveRoom();
   }

   public override void OnLeftRoom()
   {
      PhotonNetwork.LoadLevel("MainMenu");
   }
}
