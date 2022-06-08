namespace OriDeInputMod
{
    public static class HarmonyHelper
    {
        /// <summary>Return this from a prefix to skip all other prefixes and the original method</summary>
        // (I forget all the time which is which...)
        public const bool SkipMethod = false;
        /// <summary>Return this from a prefix to continue running other prefixes and the original method</summary>
        public const bool AllowMethod = true;
    }
}
