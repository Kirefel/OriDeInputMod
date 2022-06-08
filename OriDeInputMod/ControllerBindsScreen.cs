using OriDeModLoader.UIExtensions;

namespace OriDeInputMod
{
    public class ControllerBindsScreen : CustomOptionsScreen
    {
        public override void InitScreen()
        {
            this.AddControllerBind("Jump", () => ControllerRebinds.ControllerRebindings.Jump, k => ControllerRebinds.ControllerRebindings.Jump = k);
            this.AddControllerBind("Soul Link", () => ControllerRebinds.ControllerRebindings.SoulFlame, k => ControllerRebinds.ControllerRebindings.SoulFlame = k);
            this.AddControllerBind("Spirit Flame", () => ControllerRebinds.ControllerRebindings.SpiritFlame, k => ControllerRebinds.ControllerRebindings.SpiritFlame = k);
            this.AddControllerBind("Bash", () => ControllerRebinds.ControllerRebindings.Bash, k => ControllerRebinds.ControllerRebindings.Bash = k);
            this.AddControllerBind("Charge Jump", () => ControllerRebinds.ControllerRebindings.ChargeJump, k => ControllerRebinds.ControllerRebindings.ChargeJump = k);
            this.AddControllerBind("Dash", () => ControllerRebinds.ControllerRebindings.RightShoulder, k => ControllerRebinds.ControllerRebindings.RightShoulder = k);
            this.AddControllerBind("Glide", () => ControllerRebinds.ControllerRebindings.Glide, k => ControllerRebinds.ControllerRebindings.Glide = k);
            this.AddControllerBind("Grab", () => ControllerRebinds.ControllerRebindings.Grab, k => ControllerRebinds.ControllerRebindings.Grab = k);
            this.AddControllerBind("Grenade", () => ControllerRebinds.ControllerRebindings.LeftShoulder, k => ControllerRebinds.ControllerRebindings.LeftShoulder = k);
            this.AddControllerBind("Stomp", () => ControllerRebinds.ControllerRebindings.Stomp, k => ControllerRebinds.ControllerRebindings.Stomp = k);

            this.AddControllerBind("Movement Up", () => ControllerRebinds.ControllerRebindings.VerticalDigiPadUp, k => ControllerRebinds.ControllerRebindings.VerticalDigiPadUp = k);
            this.AddControllerBind("Movement Down", () => ControllerRebinds.ControllerRebindings.VerticalDigiPadDown, k => ControllerRebinds.ControllerRebindings.VerticalDigiPadDown = k);
            this.AddControllerBind("Movement Left", () => ControllerRebinds.ControllerRebindings.HorizontalDigiPadLeft, k => ControllerRebinds.ControllerRebindings.HorizontalDigiPadLeft = k);
            this.AddControllerBind("Movement Right", () => ControllerRebinds.ControllerRebindings.HorizontalDigiPadRight, k => ControllerRebinds.ControllerRebindings.HorizontalDigiPadRight = k);

            this.AddControllerBind("Pause", () => ControllerRebinds.ControllerRebindings.Start, k => ControllerRebinds.ControllerRebindings.Start = k);
            this.AddControllerBind("Map", () => ControllerRebinds.ControllerRebindings.Select, k => ControllerRebinds.ControllerRebindings.Select = k);

            this.AddControllerBind("Cancel (Menu)", () => ControllerRebinds.ControllerRebindings.Cancel, k => ControllerRebinds.ControllerRebindings.Cancel = k);
            this.AddControllerBind("Accept (Menu)", () => ControllerRebinds.ControllerRebindings.ActionButtonA, k => ControllerRebinds.ControllerRebindings.ActionButtonA = k);
            this.AddControllerBind("Menu Up", () => ControllerRebinds.ControllerRebindings.MenuUp, k => ControllerRebinds.ControllerRebindings.MenuUp = k);
            this.AddControllerBind("Menu Down", () => ControllerRebinds.ControllerRebindings.MenuDown, k => ControllerRebinds.ControllerRebindings.MenuDown = k);
            this.AddControllerBind("Menu Left", () => ControllerRebinds.ControllerRebindings.MenuLeft, k => ControllerRebinds.ControllerRebindings.MenuLeft = k);
            this.AddControllerBind("Menu Right", () => ControllerRebinds.ControllerRebindings.MenuRight, k => ControllerRebinds.ControllerRebindings.MenuRight = k);
            this.AddControllerBind("Menu Next", () => ControllerRebinds.ControllerRebindings.MenuPageRight, k => ControllerRebinds.ControllerRebindings.MenuPageRight = k);
            this.AddControllerBind("Menu Previous", () => ControllerRebinds.ControllerRebindings.MenuPageLeft, k => ControllerRebinds.ControllerRebindings.MenuPageLeft = k);
            this.AddControllerBind("Zoom In (Map)", () => ControllerRebinds.ControllerRebindings.ZoomIn, k => ControllerRebinds.ControllerRebindings.ZoomIn = k);
            this.AddControllerBind("Zoom Out (Map)", () => ControllerRebinds.ControllerRebindings.ZoomOut, k => ControllerRebinds.ControllerRebindings.ZoomOut = k);

            // Lower tooltip so it fits under the options
            var pos = tooltipController.transform.position;
            pos.y = -3.38f;
            tooltipController.transform.position = pos;
            Destroy(transform.FindChild("highlightFade/legend").gameObject);

            this.gameObject.AddComponent<MenuScroller>();
        }
    }
}
