using HarmonyLib;
using UnityEngine;

namespace GentleRain.Patches;

#if DEBUG
[HarmonyPatch(typeof(PointPinger), "ReceivePoint_Rpc")]
class PointPingerWarpPatch
{
    static void Postfix(PointPinger __instance)
    {
        if (!__instance.character.IsLocal)
        {
            return;
        }

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit raycastHit))
        {
            __instance.character.WarpPlayerRPC(raycastHit.point, false);
        }
    }
}
#endif


[HarmonyPatch(typeof(CharacterClimbing), "GetRequestedPostition")]
class CharacterClimbingGetRequestedPostitionPatch
{
    static void Prefix(CharacterClimbing __instance)
    {
        if (MapHandler.Instance.GetCurrentBiome() != Biome.BiomeType.Tropics)
        {
            return;
        }

        Traverse.Create(__instance).Field("character").GetValue<Character>().data.slippy = 0;
    }
}
