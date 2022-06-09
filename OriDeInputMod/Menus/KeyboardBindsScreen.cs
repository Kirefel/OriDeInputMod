using OriDeModLoader.UIExtensions;

namespace OriDeInputMod
{
    public class KeyboardBindsScreen : CustomOptionsScreen
    {
        public override void InitScreen()
        {
            this.AddKeybind("Jump", () => PlayerInputRebinding.KeyRebindings.Jump, k => PlayerInputRebinding.KeyRebindings.Jump = k);
            this.AddKeybind("Soul Link", () => PlayerInputRebinding.KeyRebindings.SoulFlame, k => PlayerInputRebinding.KeyRebindings.SoulFlame = k);
            this.AddKeybind("Spirit Flame", () => PlayerInputRebinding.KeyRebindings.SpiritFlame, k => PlayerInputRebinding.KeyRebindings.SpiritFlame = k);
            this.AddKeybind("Bash", () => PlayerInputRebinding.KeyRebindings.Bash, k => PlayerInputRebinding.KeyRebindings.Bash = k);
            this.AddKeybind("Charge Jump", () => PlayerInputRebinding.KeyRebindings.ChargeJump, k => PlayerInputRebinding.KeyRebindings.ChargeJump = k);
            this.AddKeybind("Dash", () => PlayerInputRebinding.KeyRebindings.RightShoulder, k => PlayerInputRebinding.KeyRebindings.RightShoulder = k);
            this.AddKeybind("Glide", () => PlayerInputRebinding.KeyRebindings.Glide, k => PlayerInputRebinding.KeyRebindings.Glide = k);
            this.AddKeybind("Grab", () => PlayerInputRebinding.KeyRebindings.Grab, k => PlayerInputRebinding.KeyRebindings.Grab = k);
            this.AddKeybind("Grenade", () => PlayerInputRebinding.KeyRebindings.LeftShoulder, k => PlayerInputRebinding.KeyRebindings.LeftShoulder = k);
            this.AddKeybind("Stomp", () => CustomKeyRebindings.KeyRebindings.Stomp, k => CustomKeyRebindings.KeyRebindings.Stomp = k);

            this.AddKeybind("Movement Up", () => PlayerInputRebinding.KeyRebindings.VerticalDigiPadUp, k => PlayerInputRebinding.KeyRebindings.VerticalDigiPadUp = k);
            this.AddKeybind("Movement Down", () => PlayerInputRebinding.KeyRebindings.VerticalDigiPadDown, k => PlayerInputRebinding.KeyRebindings.VerticalDigiPadDown = k);
            this.AddKeybind("Movement Left", () => PlayerInputRebinding.KeyRebindings.HorizontalDigiPadLeft, k => PlayerInputRebinding.KeyRebindings.HorizontalDigiPadLeft = k);
            this.AddKeybind("Movement Right", () => PlayerInputRebinding.KeyRebindings.HorizontalDigiPadRight, k => PlayerInputRebinding.KeyRebindings.HorizontalDigiPadRight = k);

            this.AddKeybind("Pause", () => PlayerInputRebinding.KeyRebindings.Start, k => PlayerInputRebinding.KeyRebindings.Start = k);
            this.AddKeybind("Map", () => PlayerInputRebinding.KeyRebindings.Select, k => PlayerInputRebinding.KeyRebindings.Select = k);
                 
            this.AddKeybind("Cancel (Menu)", () => PlayerInputRebinding.KeyRebindings.Cancel, k => PlayerInputRebinding.KeyRebindings.Cancel = k);
            this.AddKeybind("Accept (Menu)", () => PlayerInputRebinding.KeyRebindings.ActionButtonA, k => PlayerInputRebinding.KeyRebindings.ActionButtonA = k);
            this.AddKeybind("Menu Up", () => PlayerInputRebinding.KeyRebindings.MenuUp, k => PlayerInputRebinding.KeyRebindings.MenuUp = k);
            this.AddKeybind("Menu Down", () => PlayerInputRebinding.KeyRebindings.MenuDown, k => PlayerInputRebinding.KeyRebindings.MenuDown = k);
            this.AddKeybind("Menu Left", () => PlayerInputRebinding.KeyRebindings.MenuLeft, k => PlayerInputRebinding.KeyRebindings.MenuLeft = k);
            this.AddKeybind("Menu Right", () => PlayerInputRebinding.KeyRebindings.MenuRight, k => PlayerInputRebinding.KeyRebindings.MenuRight = k);
            this.AddKeybind("Menu Next", () => PlayerInputRebinding.KeyRebindings.MenuPageRight, k => PlayerInputRebinding.KeyRebindings.MenuPageRight = k);
            this.AddKeybind("Menu Previous", () => PlayerInputRebinding.KeyRebindings.MenuPageLeft, k => PlayerInputRebinding.KeyRebindings.MenuPageLeft = k);
            this.AddKeybind("Zoom In (Map)", () => PlayerInputRebinding.KeyRebindings.ZoomIn, k => PlayerInputRebinding.KeyRebindings.ZoomIn = k);
            this.AddKeybind("Zoom Out (Map)", () => PlayerInputRebinding.KeyRebindings.ZoomOut, k => PlayerInputRebinding.KeyRebindings.ZoomOut = k);

            // Lower tooltip so it fits under the options
            var pos = tooltipController.transform.position;
            pos.y = -3.38f;
            pos.x = -pos.x;
            tooltipController.transform.position = pos;
            Destroy(transform.FindChild("highlightFade/legend").gameObject);

            this.gameObject.AddComponent<MenuScroller>();
        }
    }
}
