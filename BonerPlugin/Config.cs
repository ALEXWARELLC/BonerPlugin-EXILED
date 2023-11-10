using System.ComponentModel;
using Exiled.API.Interfaces;

namespace BonerPlugin
{
    public sealed class Config : IConfig
    {
        public Config()
        {
        }

        public bool IsEnabled { get; set; } = true;
        public bool Debug { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        [Description("The default rule for this plugin ('false') is to not make 3114 a 100 percent spawn chance (leaving it to the default game system with a 30 percent chance) if someone spawns as 079, set this to 'true' to make the plugin ignore this rule (this should be used for events like 'the max players for the server is 100 for 2 hours')")]
        public bool NoComputerOveride { get; set; } = false;
    }
}
