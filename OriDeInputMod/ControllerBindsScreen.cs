using OriDeModLoader.UIExtensions;

namespace OriDeInputMod
{
    public class ControllerBindsScreen : CustomOptionsScreen
    {
        public override void InitScreen()
        {
            this.AddControllerBind("Bash", () => ControllerRebinds.ControllerRebindings.Bash, k => ControllerRebinds.ControllerRebindings.Bash = k);
            this.AddControllerBind("Charge Jump", () => ControllerRebinds.ControllerRebindings.ChargeJump, k => ControllerRebinds.ControllerRebindings.ChargeJump = k);
            this.AddControllerBind("Dash", () => ControllerRebinds.ControllerRebindings.RightShoulder, k => ControllerRebinds.ControllerRebindings.RightShoulder = k);
            this.AddControllerBind("Glide", () => ControllerRebinds.ControllerRebindings.Glide, k => ControllerRebinds.ControllerRebindings.Glide = k);
            this.AddControllerBind("Grab", () => ControllerRebinds.ControllerRebindings.Grab, k => ControllerRebinds.ControllerRebindings.Grab = k);
            this.AddControllerBind("Grenade", () => ControllerRebinds.ControllerRebindings.LeftShoulder, k => ControllerRebinds.ControllerRebindings.LeftShoulder = k);
            this.AddControllerBind("Jump", () => ControllerRebinds.ControllerRebindings.Jump, k => ControllerRebinds.ControllerRebindings.Jump = k);
            this.AddControllerBind("Soul Link", () => ControllerRebinds.ControllerRebindings.SoulFlame, k => ControllerRebinds.ControllerRebindings.SoulFlame = k);
            this.AddControllerBind("Spirit Flame", () => ControllerRebinds.ControllerRebindings.SpiritFlame, k => ControllerRebinds.ControllerRebindings.SpiritFlame = k);
            this.AddControllerBind("Stomp", () => ControllerRebinds.ControllerRebindings.Stomp, k => ControllerRebinds.ControllerRebindings.Stomp = k);
            this.AddControllerBind("Movement Up", () => ControllerRebinds.ControllerRebindings.VerticalDigiPadUp, k => ControllerRebinds.ControllerRebindings.VerticalDigiPadUp = k);
            this.AddControllerBind("Movement Down", () => ControllerRebinds.ControllerRebindings.VerticalDigiPadDown, k => ControllerRebinds.ControllerRebindings.VerticalDigiPadDown = k);
            this.AddControllerBind("Movement Left", () => ControllerRebinds.ControllerRebindings.HorizontalDigiPadLeft, k => ControllerRebinds.ControllerRebindings.HorizontalDigiPadLeft = k);
            this.AddControllerBind("Movement Right", () => ControllerRebinds.ControllerRebindings.HorizontalDigiPadRight, k => ControllerRebinds.ControllerRebindings.HorizontalDigiPadRight = k);

            // Lower tooltip so it fits under the options
            var pos = tooltipController.transform.position;
            pos.y = -3.38f;
            tooltipController.transform.position = pos;
            Destroy(transform.FindChild("highlightFade/legend").gameObject);
        }
    }
}
