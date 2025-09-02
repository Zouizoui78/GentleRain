using HarmonyLib;
using UnityEngine;

namespace GentleRain.Patches;

#if DEBUG
[HarmonyPatch(typeof(PointPinger), "ReceivePoint_Rpc")]
class PointPingerWarpPatch
{
    static void Postfix(PointPinger __instance)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit) && __instance.character.IsLocal)
        {
            __instance.character.WarpPlayerRPC(raycastHit.point, false);
        }
    }
}
#endif
