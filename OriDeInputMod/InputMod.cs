using HarmonyLib;
using OriDeModLoader;
using OriDeModLoader.UIExtensions;

namespace OriDeInputMod
{
    public class InputMod : IMod
    {
        public string Name => "Rebinding";

        private Harmony harmony;

        public void Init()
        {
            harmony = new Harmony("orideinputmod");
            harmony.PatchAll();

            CustomMenuManager.RegisterOptionsScreen<KeyboardBindsScreen>("KEYBINDS", 0);
            CustomMenuManager.RegisterOptionsScreen<ControllerBindsScreen>("CONTROLLER", 1);
        }

        public void Unload()
        {

        }
    }
}
