using Snakk.API.PluginFramework;

namespace Snakk.API.Plugin.MyPlugin1
{
    public class BasePlugin : IPlugin
    {
        public string GetId() => PluginInfo.Id;

        public string GetName() => PluginInfo.Name;
    }
}
