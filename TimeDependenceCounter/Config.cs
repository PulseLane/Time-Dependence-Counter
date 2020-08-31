namespace TimeDependenceCounter
{
    class Config
    {
        public static BS_Utils.Utilities.Config config = new BS_Utils.Utilities.Config("TimeDependenceCounter");
        public static bool separateSaber = true;
        public static int decimalPrecision = 2;
        public static bool multiply = false;

        public static void Read()
        {
            separateSaber = config.GetBool("TimeDependenceCounter", "separateSaber", true, true);
            decimalPrecision = config.GetInt("TimeDependenceCounter", "decimalPrecision", 2, true);
            multiply = config.GetBool("TimeDependenceCounter", "multiply", false, true);
        }

        public static void Write()
        {
            config.SetBool("TimeDependenceCounter", "separateSaber", separateSaber);
            config.SetInt("TimeDependenceCounter", "decimalPrecision", decimalPrecision);
            config.SetBool("TimeDependenceCounter", "multiply", multiply);
        }
    }
}
