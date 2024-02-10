using HarmonyLib;
using MonkeNotificationLib;
using Photon.Pun;
using UnityEngine;

namespace ShinyUtils.Patches
{
    [HarmonyPatch(typeof(VRRig), "PlaySplashEffect")]
    internal class SplashRPCPatch
    {
        static void Postfix(PhotonMessageInfo info)
        {
            NotificationController.AppendMessage("ShinyUtils", "Splash".WrapColor("green") + " RPC called by: " + info.Sender.NickName.WrapColor("green"));

            Debug.Log("Splash" + " RPC called by: " + info.Sender.NickName);
        }
    }
}