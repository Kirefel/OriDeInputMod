using System;
using OriDeModLoader.UIExtensions;
using UnityEngine;

namespace OriDeInputMod
{
    public static class Extensions
    {
        public static void AddKeybind(this CustomOptionsScreen screen, string label, Func<KeyCode[]> getKeys, Action<KeyCode[]> setKeys)
        {
            CleverMenuItem cleverMenuItem = screen.AddItem(label);
            cleverMenuItem.gameObject.name = "Keybind (" + label + ")";
            KeybindControl kc = cleverMenuItem.gameObject.AddComponent<KeybindControl>();
            kc.Init(getKeys, setKeys, screen);
            cleverMenuItem.PressedCallback += delegate ()
            {
                kc.BeginEditing();
            };
        }

        public static void AddControllerBind(this CustomOptionsScreen screen, string label, Func<ControllerRebinds.ControllerButton[]> getKeys, Action<ControllerRebinds.ControllerButton[]> setKeys)
        {
            CleverMenuItem cleverMenuItem = screen.AddItem(label);
            cleverMenuItem.gameObject.name = "Controller Bind (" + label + ")";
            ControllerBindControl kc = cleverMenuItem.gameObject.AddComponent<ControllerBindControl>();
            kc.Init(getKeys, setKeys, screen);
            cleverMenuItem.PressedCallback += delegate ()
            {
                kc.BeginEditing();
            };
        }
    }
}
