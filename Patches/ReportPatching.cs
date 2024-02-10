using HarmonyLib;
using MonkeNotificationLib;
using Photon.Pun;
using UnityEngine;

namespace ShinyUtils.Patches
{
    [HarmonyPatch(typeof(GorillaNot), "SendReport")]
    internal class ReportPatching
    {
        static void Postfix(string susReason, string susId, string susNick)
        {
            NotificationController.AppendMessage("ShinyUtils", "Anticheat reported ".WrapColor("red") + susNick.WrapColor("red") + " for ".WrapColor("red") + susReason.WrapColor("red"));

            Debug.Log("Anticheat reported " + susNick + " for " + susReason + " (Room: " + PhotonNetwork.CurrentRoom.Name + ")");
        }
    }
}