using BepInEx;
using Photon.Pun;
using MonkeNotificationLib;
using UnityEngine;

namespace ShinyUtils
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]

    public class Plugin : BaseUnityPlugin
    {
        bool active;

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            active = true;
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
            active = false;
        }

        public bool AlreadyDone = false;
        public bool MasterThingy = false;
        public bool StartThingy = false;

        public string TheRoom;
        void Update()
        {
//          == Start fixer ==
            if (GorillaTagger.Instance != null && !StartThingy)
            {
                FixedStart();
                StartThingy = true;
            }

            if (active)
            {
//              == Room joining / Leaving ==

                if (PhotonNetwork.InRoom && !AlreadyDone)
                {
                    TheRoom = PhotonNetwork.CurrentRoom.Name;
                    MonkeNotificationLib.NotificationController.AppendMessage("ShinyUtils", "Joined room: " + TheRoom.WrapColor("green"));
                    AlreadyDone = true;
                }

                if (!PhotonNetwork.InRoom && AlreadyDone)
                {
                    MonkeNotificationLib.NotificationController.AppendMessage("ShinyUtils", "Left room: " + TheRoom.WrapColor("green"));
                    AlreadyDone = false;
                }

//              == Master ==

                if (PhotonNetwork.IsMasterClient && !MasterThingy)
                {
                    MonkeNotificationLib.NotificationController.AppendMessage("ShinyUtils", "User is now " + "MASTER CLIENT".WrapColor("green"));
                    MasterThingy = true;
                }

                if (!PhotonNetwork.IsMasterClient && MasterThingy)
                {
                    MasterThingy = false;
                }
            }
        }
        void FixedStart()
        {
            MonkeNotificationLib.NotificationController.AppendMessage("ShinyUtils", "ShinyUtils loaded");
            Camera.main.useOcclusionCulling = true;
            MonkeNotificationLib.NotificationController.AppendMessage("ShinyUtils", "Fixed lag: " + Camera.main.useOcclusionCulling.ToString().WrapColor("green"));
            Debug.Log("You found the Shiny Utils secret :D");
        }

/* Ultra sigma ohio griddy */

    }
}