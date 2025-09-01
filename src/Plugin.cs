using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace GentleRain;

[BepInPlugin("org.zouizoui.peakmods.gentlerain", "Gentle Rain", "0.0.1")]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    private void Awake()
    {
        // Plugin startup logic
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony("org.zouizoui.peakmods.gentlerain");
        harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(PointPing), "Start")]
class PointPingStartPath
{
    static void Prefix()
    {
        Plugin.Logger.LogInfo("Triggered by pointing !!!");
    }
}
