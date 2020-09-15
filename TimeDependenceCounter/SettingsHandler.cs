using BeatSaberMarkupLanguage.Attributes;

namespace TimeDependenceCounter
{
    class SettingsHandler
    {
        [UIValue("separateSaber")]
        public bool separateSaber
        {
            get => Configuration.Instance.separateSaber;
            set
            {
                Configuration.Instance.separateSaber = value;
            }
        }

        [UIValue("decimalPrecision")]
        public int decimalPrecision
        {
            get => Configuration.Instance.decimalPrecision;
            set
            {
                Configuration.Instance.decimalPrecision = value;
            }
        }

        [UIValue("multiply")]
        public bool multiply
        {
            get => Configuration.Instance.multiply;
            set
            {
                Configuration.Instance.multiply = value;
            }
        }
    }
}
