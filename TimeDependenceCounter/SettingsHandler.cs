using BeatSaberMarkupLanguage.Attributes;

namespace TimeDependenceCounter
{
    class SettingsHandler
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

        [UIValue("multiply")]
        public bool multiply
        {
            get => Config.multiply;
            set
            {
                Config.multiply = value;
                Config.Write();
            }
        }
    }
}
