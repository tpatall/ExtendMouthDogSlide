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

            configSlideDuration = cfg.BindSyncedEntry("ExtendMouthDogSlide", "SlideDuration", 2.3f, "Duration of the slide after a lunge in seconds.");
            configTopSpeed = cfg.BindSyncedEntry("ExtendMouthDogSlide", "TopSpeed", 13f, "Starting speed of the lunge.");
            configAlwaysTopSpeed = cfg.BindSyncedEntry("ExtendMouthDogSlide", "AlwaysTopSpeed", false, "If the whole slide is at top speed.");
        }
    }
}
