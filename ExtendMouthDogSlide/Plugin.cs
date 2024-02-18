using BepInEx;
using ExtendMouthDogSlide.Patches;
using HarmonyLib;

namespace ExtendMouthDogSlide
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

        public static Plugin instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

            _ = new ConfigSettings(Config);

            harmony.PatchAll(typeof(Plugin));            
            harmony.PatchAll(typeof(MouthDogAIPatch));
            harmony.PatchAll(typeof(ConfigSettings));

            this.Logger.LogInfo(PluginInfo.PLUGIN_NAME + " loaded");
        }

        public static void Log(string message)
        {
            instance.Logger.LogInfo($"{message}");
        }

        public static void LogError(string message) 
        { 
            instance.Logger.LogError(message); 
        }
    }
}
