using BeatSaberMarkupLanguage.Attributes;
using BS_Utils.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TimeDependenceCounter
{
    class SettingsHandler : MonoBehaviour
    {
        [UIValue("separateSaber")]
        public bool separateSaber
        {
            get => Config.separateSaber;
            set
            {
                Config.separateSaber = value;
                Config.Write();
            }
        }

        [UIValue("decimalPrecision")]
        public int decimalPrecision
        {
            get => Config.decimalPrecision;
            set
            {
                Config.decimalPrecision = value;
                Config.Write();
            }
        }
    }
}
