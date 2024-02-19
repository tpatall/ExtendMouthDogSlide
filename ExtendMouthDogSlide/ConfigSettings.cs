using BepInEx.Configuration;
using CSync.Lib;
using CSync.Util;
using System.Runtime.Serialization;

namespace ExtendMouthDogSlide
{
    [DataContract]
    public class ConfigSettings : SyncedInstance<ConfigSettings>
    {
        [DataMember] public SyncedEntry<float> configSlideDuration { get; private set; }
        [DataMember] public SyncedEntry<float> configTopSpeed { get; private set; }
        [DataMember] public SyncedEntry<bool> configAlwaysTopSpeed { get; private set; }

        public ConfigSettings(ConfigFile cfg)
        {
            EasySync.SyncManager.RegisterForSyncing(this, PluginInfo.PLUGIN_GUID);

            configSlideDuration =   cfg.BindSyncedEntry("SlipperyDogs", "SlideDuration", 5f, "Duration of the slide after a lunge in seconds. For vanilla settings set this to 2.3.");
            configTopSpeed =        cfg.BindSyncedEntry("SlipperyDogs", "TopSpeed", 15f, "Starting speed of the lunge. For vanilla settings, set this to 13.");
            configAlwaysTopSpeed =  cfg.BindSyncedEntry("SlipperyDogs", "AlwaysTopSpeed", true, "If the whole slide is at top speed. For vanilla settings, set this to false.");
        }
    }
}
