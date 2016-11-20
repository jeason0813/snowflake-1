using Snowflake.Configuration;
using Snowflake.Configuration.Attributes;

//autogenerated using generate_retroarch.py
namespace Snowflake.Plugin.EmulatorAdapter.RetroArch.Configuration.Internal
{
   [ConfigurationSection("stdin", "Stdin Options")]
 public interface StdinConfiguration : IConfigurationSection<StdinConfiguration>
    {
        //use network cmds on windows instead
        [ConfigurationOption("stdin_cmd_enable",false, DisplayName = "Enable Commands through STDIN", Private = true)]
        bool StdinCmdEnable { get; set; }

    }
}

