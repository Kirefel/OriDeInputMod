using OriDeModLoader;
using OriDeModLoader.UIExtensions;

namespace OriDeInputMod
{
    public class InputMod : IMod
    {
        public string Name => "Rebinding";

        public void Init()
        {
            CustomMenuManager.RegisterOptionsScreen<KeyboardBindsScreen>("KEYBINDS", 0);
            CustomMenuManager.RegisterOptionsScreen<ControllerBindsScreen>("CONTROLLER", 1);
        }

        public void Unload()
        {

        }
    }
}
