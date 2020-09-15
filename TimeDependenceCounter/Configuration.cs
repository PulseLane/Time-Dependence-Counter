using IPA.Config.Stores;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace TimeDependenceCounter
{
    class Configuration
    {
        public static Configuration Instance { get; set; }
        public virtual bool separateSaber { get; set; } = true;
        public virtual int decimalPrecision { get; set; } = 2;
        public virtual bool multiply { get; set; } = false;
    }
}
