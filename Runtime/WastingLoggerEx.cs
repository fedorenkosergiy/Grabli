using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Grabli
{
    public static class WastingLoggerEx
    {
        public const string ValueDidntChange = "Value didn't change";
        public const string SameObject = "Same object";

        [Conditional(Defines.WARNING_WASTING_CODE_RUNS)]
        [Conditional(Defines.UNITY_EDITOR)]
        public static void LogWarningValueDidntChange(this WastingLogger unused, bool prev, bool next)
        {
            if (prev == next)
            {
                Debug.LogWarning(ValueDidntChange);
            }
        }
        
        [Conditional(Defines.WARNING_WASTING_CODE_RUNS)]
        [Conditional(Defines.UNITY_EDITOR)]
        public static void LogWarningValueDidntChange(this WastingLogger unused, string prev, string next)
        {
            if (prev == next)
            {
                Debug.LogWarning(ValueDidntChange);
            }
        }
        
        [Conditional(Defines.WARNING_WASTING_CODE_RUNS)]
        [Conditional(Defines.UNITY_EDITOR)]
        public static void LogWarningSameObject<T>(this WastingLogger unused, T prev, T next) where T : class
        {
            if (prev == next)
            {
                Debug.LogWarning(SameObject);
            }
        }
    }
}