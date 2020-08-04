using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CountersPlus.Custom;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Loader;
using UnityEngine;
using static TimeDependenceCounter.ConfigLoader;
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
            instance = this;
            Logger.log = logger;
            Logger.log.Debug("Logger initialized.");
        }

        [OnEnable]
        public void OnEnable()
        {
            Config.Read();
            CreateTimeDependenceCounter();
            BS_Utils.Utilities.BSEvents.gameSceneActive += OnGameSceneActive;

        }

        [OnDisable]
        public void OnDisable()
        {
            BS_Utils.Utilities.BSEvents.gameSceneActive -= OnGameSceneActive;
        }

        public void OnGameSceneActive()
        {
            MainConfigModel model = ConfigLoader.LoadTimeDependenceConfig();
            if (model.timeDependenceConfig.Enabled)
                new GameObject("Time Dependence Counter").AddComponent<TimeDependenceCounter>();
        }

        private void CreateTimeDependenceCounter()
        {
            CustomCounter counter = new CustomCounter
            {
                SectionName = "Time Dependence Counter",
                Name = "Time Dependence",
                BSIPAMod = PluginManager.EnabledPlugins.First(x => x.Name == Name),
                Counter = "Time Dependence Counter",
                Description = "Shows the average time dependence of your cuts",
                CustomSettingsResource = "TimeDependenceCounter.settings.bsml",
                CustomSettingsHandler = typeof(SettingsHandler)
            };

            CustomCounterCreator.Create(counter);
        }
    }
}
