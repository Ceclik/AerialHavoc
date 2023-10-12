using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomCreator : MonoBehaviourPunCallbacks
{
   [SerializeField] private InputField roomNameField;
   [SerializeField] private Color targetColorToWrongTextField;
   [SerializeField] private Text errorText;
   private bool _isErrorShown = false;

   public void OnCreateButtonClick()
   {
      if (roomNameField.text.Length > 2)
      {
         if (_isErrorShown)
         {
            _isErrorShown = false;
            roomNameField.GetComponent<Image>().color = Color.white;
            errorText.enabled = false;
         }
         RoomOptions roomOptions = new RoomOptions();
         roomOptions.MaxPlayers = 4;
         PhotonNetwork.CreateRoom(roomNameField.text, roomOptions);
      }
      else
      {
         _isErrorShown = true;
         roomNameField.GetComponent<Image>().color = targetColorToWrongTextField;
         errorText.enabled = true;
      }
   }
   
   public override void OnCreatedRoom()
   {
      PhotonNetwork.LoadLevel("Gameplay");  
   }
}
