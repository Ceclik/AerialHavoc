using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomVariantsSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private RoomVariantButton roomVariantButton;
    [SerializeField] private Transform content;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var info in roomList)
        {
            RoomVariantButton spawnedItem = Instantiate(roomVariantButton, content);
            if(spawnedItem != null)
                spawnedItem.SetInfo(info);
        }
    }
}
