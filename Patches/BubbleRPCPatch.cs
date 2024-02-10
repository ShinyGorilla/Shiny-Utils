using HarmonyLib;
using UnityEngine;
using MonkeNotificationLib;
using GorillaTag;
using Photon.Pun;

namespace ShinyUtils.Patches
{
    [HarmonyPatch(typeof(ScienceExperimentPlatformGenerator), "SpawnSodaBubbleRPC")]
    internal class BubbleRPCPatch
    {
        static void Postfix(PhotonMessageInfo info)
        {
            if (info.Sender.IsMasterClient)
            {
                NotificationController.AppendMessage("ShinyUtils", "Bubble ".WrapColor("green") + " RPC called by: " + info.Sender.NickName.WrapColor("blue") + " (MASTER CLIENT)".WrapColor("green"));

                Debug.Log("Bubble RPC called by: " + info.Sender.NickName + " (MASTER CLIENT)");
            }
            else
            {
                NotificationController.AppendMessage("ShinyUtils", "Bubble".WrapColor("green") + " RPC called by: " + info.Sender.NickName.WrapColor("blue") + " (NON MASTER CLIENT)".WrapColor("red"));

                Debug.Log("Bubble RPC called by: " + info.Sender.NickName);
            }
        }
    }
}