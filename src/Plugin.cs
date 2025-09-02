using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace GentleRain;

[BepInPlugin("org.zouizoui.peakmods.gentlerain", "Gentle Rain", "0.0.1")]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;

    private void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        var harmony = new Harmony("org.zouizoui.peakmods.gentlerain");
        harmony.PatchAll();
    }

    public void Update()
    {
#if DEBUG
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            MapHandler.JumpToSegment(Segment.Beach);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            MapHandler.JumpToSegment(Segment.Tropics);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha3))
        {
            MapHandler.JumpToSegment(Segment.Alpine);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha4))
        {
            MapHandler.JumpToSegment(Segment.Caldera);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha5))
        {
            MapHandler.JumpToSegment(Segment.TheKiln);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha6))
        {
            MapHandler.JumpToSegment(Segment.Peak);
        }
#endif
    }
}
