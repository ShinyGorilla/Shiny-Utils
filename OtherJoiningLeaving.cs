using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using MonkeNotificationLib;

internal class OtherJoiningLeaving : MonoBehaviourPunCallbacks
{
    public OtherJoiningLeaving()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        NotificationController.AppendMessage("ShinyUtils", newPlayer.NickName.WrapColor("green") + " joined the room");

        Debug.Log(newPlayer.NickName + " joined the room (" + PhotonNetwork.CurrentRoom.Name + ")");
    }
}