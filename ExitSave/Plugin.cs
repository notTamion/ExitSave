using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using TestingMod.Patches;

namespace ExitSave;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin{
    private const string GUID = "tamion.TestingModj";
    private const string Name = "Testing Mod";
    private const string Version = "1.0.0";

    private readonly Harmony harmony = new Harmony(GUID);
    
    public override void Load(){
        harmony.PatchAll(typeof(MainMenuControllerPatch));
    }
}