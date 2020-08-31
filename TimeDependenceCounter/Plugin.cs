using IPA;
using IPA.Config;
using IPALogger = IPA.Logging.Logger;

namespace TimeDependenceCounter
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Plugin instance { get; private set; }
        internal static string Name => "TimeDependenceCounter";

        [Init]
        public Plugin(IPALogger logger)
        {
            Config.Read();
            instance = this;
            Logger.log = logger;
            Logger.log.Debug("Logger initialized.");
        }

        [OnEnable]
        public void OnEnable() {}

        [OnDisable]
        public void OnDisable() {}
    }
}
