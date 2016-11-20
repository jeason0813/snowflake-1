using Snowflake.Configuration;
using Snowflake.Configuration.Attributes;

//autogenerated using generate_retroarch.py
namespace Snowflake.Plugin.EmulatorAdapter.RetroArch.Configuration.Internal
{
   [ConfigurationSection("core", "Core Options")]
 public interface CoreConfiguration : IConfigurationSection<CoreConfiguration>
    {
        [ConfigurationOption("core_set_supports_no_game_enable",true, DisplayName = "Core Set Supports No Game Enable", Private = true)]
        bool CoreSetSupportsNoGameEnable { get; set; }
        [ConfigurationOption("core_specific_config",false, DisplayName = "Core Specific Config", Private = true)]
        bool CoreSpecificConfig { get; set; }
        [ConfigurationOption("core_updater_auto_extract_archive",true, DisplayName = "Core Updater Auto Extract Archive", Private = true)]
        bool CoreUpdaterAutoExtractArchive { get; set; }
        [ConfigurationOption("core_updater_buildbot_assets_url","http://buildbot.libretro.com/assets/", DisplayName = "Core Updater Buildbot Assets Url", Private = true)]
        string CoreUpdaterBuildbotAssetsUrl { get; set; }
        [ConfigurationOption("core_updater_buildbot_url","http://buildbot.libretro.com/nightly/win-x86_64/latest/", DisplayName = "Core Updater Buildbot Url", Private = true)]
        string CoreUpdaterBuildbotUrl { get; set; }

        [ConfigurationOption("load_dummy_on_core_shutdown",true, DisplayName = "Load Dummy On Core Shutdown")]
        bool LoadDummyOnCoreShutdown { get; set; }

    }
}

