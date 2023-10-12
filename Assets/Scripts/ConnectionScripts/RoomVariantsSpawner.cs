using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomVariantsSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private RoomVariantButton roomVariantButton;
    private RectTransform[] _spawnedRoomButtons;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        _spawnedRoomButtons = transform.GetComponentsInChildren<RectTransform>();
        for(int i = 1; i < _spawnedRoomButtons.Length; i++)
            Destroy(_spawnedRoomButtons[i].gameObject);
        foreach (var info in roomList)
        {
            if (info.MaxPlayers > 2)
            {
                RoomVariantButton spawnedItem = Instantiate(roomVariantButton, transform);
                if (spawnedItem != null)
                    spawnedItem.SetInfo(info);
            }
        }
    }
}
