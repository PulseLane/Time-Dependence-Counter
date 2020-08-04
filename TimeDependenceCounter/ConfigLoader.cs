using CountersPlus.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TimeDependenceCounter
{
    class ConfigLoader : CountersPlus.Config.ConfigLoader
    {
        internal static BS_Utils.Utilities.Config config = new BS_Utils.Utilities.Config("CountersPlus");
        public static MainConfigModel LoadTimeDependenceConfig()
        {
            MainConfigModel model = new MainConfigModel();
            model = DeserializeFromConfig(model, model.DisplayName);
            try
            {
                model.timeDependenceConfig = DeserializeFromConfig(model.timeDependenceConfig, model.timeDependenceConfig.DisplayName);
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(NullReferenceException)) Logger.log.Error(e.ToString());
            }
            return model;
        }

        public class MainConfigModel : CountersPlus.Config.MainConfigModel
        {
            public TimeDependenceConfigModel timeDependenceConfig = new TimeDependenceConfigModel();
        }

        public sealed class TimeDependenceConfigModel : ConfigModel
        {
            public TimeDependenceConfigModel()
            {
                DisplayName = "Time Dependence Counter";
                Enabled = true; Position = ICounterPositions.BelowCombo; Distance = 3;
            }
        }

        // CountersPlus ConfigModel is internal-set so need to redefine here
        public abstract class ConfigModel
        {
            public string DisplayName { get; internal set; } // DisplayName should not be changed once set.
            public bool Enabled;
            public ICounterPositions Position;
            public int Distance;

            public void Save()
            {
                MemberInfo[] infos = GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance);
                foreach (MemberInfo info in infos)
                {
                    if (info.MemberType != MemberTypes.Field) continue;
                    FieldInfo finfo = (FieldInfo)info;
                    ConfigLoader.config.SetString(DisplayName, info.Name, finfo.GetValue(this).ToString());
                }
            }
        }
    }
}
