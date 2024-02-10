using HarmonyLib;
using Photon.Realtime;
using MonkeNotificationLib;
using UnityEngine;

namespace ShinyUtils.Patches
{
    [HarmonyPatch(typeof(SlingshotProjectile), "Launch")]
    internal class ProjectileRPCPatch
    {
        static void Postfix(Player player)
        {
            NotificationController.AppendMessage("ShinyUtils", "Projectile".WrapColor("green") + " RPC called by: " + player.NickName.WrapColor("green"));

            Debug.Log("Projectile" + " RPC called by: " + player.NickName);
        }
    }
}