using HarmonyLib;

namespace OriDeInputMod
{
    [HarmonyPatch]
    internal class ExtraInputHandler
    {
        [HarmonyPostfix, HarmonyPatch(typeof(PlayerInput), nameof(PlayerInput.ClearControls))]
        private static void ClearControls() => CustomInput.ClearControls();

        [HarmonyPostfix, HarmonyPatch(typeof(PlayerInput), nameof(PlayerInput.AddKeyboardControls))]
        private static void AddKeyboardControls() => CustomInput.AddKeyboardControls();

        [HarmonyPostfix, HarmonyPatch(typeof(PlayerInput), nameof(PlayerInput.FixedUpdate))]
        private static void FixedUpdate() => CustomInput.FixedUpdate();

        [HarmonyPrefix, HarmonyPatch(typeof(PlayerInput), nameof(PlayerInput.AddControllerControls))] // TODO replace method, include all binds
        private static bool AddControllerControls()
        {
            CustomInput.AddControllerControls();
            return HarmonyHelper.SkipMethod;
        }
    }
}
