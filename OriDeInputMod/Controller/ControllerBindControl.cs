﻿using System;
using System.Collections.Generic;
using BaseModLib;
using OriDeModLoader.UIExtensions;
using SmartInput;
using UnityEngine;

namespace OriDeInputMod
{
    public class ControllerBindControl : MonoBehaviour
    {
        private const string DefaultTooltip = "[Accept] to change bind    <icon>k</>+[Accept] to append bind";


        private Action<ControllerRebinds.ControllerButton[]> SetKeys;

        private bool editing;

        private MessageBox messageBox;

        private readonly List<ControllerRebinds.ControllerButton> currentKeys = new List<ControllerRebinds.ControllerButton>();

        private int exit;

        private bool[] buttonsPressed;

        private XboxControllerInput.Button[] allButtons;

        private CustomOptionsScreen owner;

        private BasicMessageProvider tooltipProvider;

        public void Init(Func<ControllerRebinds.ControllerButton[]> getKeys, Action<ControllerRebinds.ControllerButton[]> setKeys, CustomOptionsScreen owner)
        {
            this.owner = owner;
            SetKeys = setKeys;
            currentKeys.AddRange(getKeys());
            messageBox.SetMessage(new MessageDescriptor(KeyBindingToString(currentKeys.ToArray())));
            CleverMenuItemTooltip component = base.GetComponent<CleverMenuItemTooltip>();
            tooltipProvider = ScriptableObject.CreateInstance<BasicMessageProvider>();
            tooltipProvider.SetMessage(DefaultTooltip);
            component.Tooltip = tooltipProvider;
            owner.tooltipController.UpdateTooltip();
        }

        private void Awake()
        {
            messageBox = base.transform.Find("text/stateText").GetComponent<MessageBox>();
        }

        public void BeginEditing()
        {
            bool appendMode = XboxControllerInput.GetButton(XboxControllerInput.Button.RightTrigger);

            if (!appendMode)
                currentKeys.Clear();

            UpdateMessageBox();
            SuspensionManager.SuspendAll();
            editing = true;
            exit = 0;
            allButtons = (XboxControllerInput.Button[])Enum.GetValues(typeof(XboxControllerInput.Button));
            buttonsPressed = new bool[allButtons.Length];
            for (int i = 0; i < buttonsPressed.Length; i++)
            {
                buttonsPressed[i] = true;
            }

            if (appendMode)
                tooltipProvider.SetMessage("Press any button to append bind");
            else
                tooltipProvider.SetMessage("Press any button to change bind");

            owner.tooltipController.UpdateTooltip();
        }

        private void Update()
        {
            if (!editing)
            {
                return;
            }
            if (exit < 2)
            {
                exit++;
                return;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                FinishEditing();

            ControllerRebinds.ControllerButton? pressedButtonAsBind = GetPressedButtonAsBind();
            if (pressedButtonAsBind != null)
            {
                if (!currentKeys.Contains(pressedButtonAsBind.Value))
                    currentKeys.Add(pressedButtonAsBind.Value);

                FinishEditing();
            }

            foreach (XboxControllerInput.Button button in allButtons)
            {
                buttonsPressed[(int)button] = XboxControllerInput.GetButton(button);
            }
        }

        private void FinishEditing()
        {
            UpdateMessageBox();

            editing = false;
            SuspensionManager.ResumeAll();
            SetKeys(currentKeys.ToArray());
            ControllerRebinds.WriteControllerRebindSettings();
            PlayerInput.Instance.RefreshControlScheme();
            tooltipProvider.SetMessage(DefaultTooltip);
            owner.tooltipController.UpdateTooltip();
        }

        public void UpdateMessageBox()
        {
            messageBox.SetMessage(new MessageDescriptor(KeyBindingToString(currentKeys.ToArray())));
        }

        private static string KeyBindingToString(ControllerRebinds.ControllerButton[] codes)
        {
            string text = string.Empty;
            bool flag = true;
            foreach (ControllerRebinds.ControllerButton controllerButton in codes)
            {
                text += (!flag) ? ", " : string.Empty;
                text += controllerButton.ButtonToIcon();
                flag = false;
            }
            return text;
        }

        private bool WasPressed(XboxControllerInput.Button button)
        {
            return !buttonsPressed[(int)button] && XboxControllerInput.GetButton(button, -1);
        }

        private ControllerRebinds.ControllerButton ToBind(XboxControllerInput.Button button)
        {
            switch (button)
            {
                case XboxControllerInput.Button.ButtonA: return ControllerRebinds.ControllerButton.A;
                case XboxControllerInput.Button.ButtonX: return ControllerRebinds.ControllerButton.X;
                case XboxControllerInput.Button.ButtonY: return ControllerRebinds.ControllerButton.Y;
                case XboxControllerInput.Button.ButtonB: return ControllerRebinds.ControllerButton.B;
                case XboxControllerInput.Button.LeftTrigger: return ControllerRebinds.ControllerButton.LT;
                case XboxControllerInput.Button.RightTrigger: return ControllerRebinds.ControllerButton.RT;
                case XboxControllerInput.Button.LeftShoulder: return ControllerRebinds.ControllerButton.LB;
                case XboxControllerInput.Button.RightShoulder: return ControllerRebinds.ControllerButton.RB;
                case XboxControllerInput.Button.LeftStick: return ControllerRebinds.ControllerButton.LS;
                case XboxControllerInput.Button.RightStick: return ControllerRebinds.ControllerButton.RS;
                case XboxControllerInput.Button.Select: return ControllerRebinds.ControllerButton.Back;
                case XboxControllerInput.Button.Start: return ControllerRebinds.ControllerButton.Start;
                default: return ControllerRebinds.ControllerButton.A;
            }
        }

        private ControllerRebinds.ControllerButton? GetPressedButtonAsBind()
        {
            foreach (XboxControllerInput.Button button in allButtons)
            {
                if (WasPressed(button))
                {
                    return ToBind(button);
                }
            }
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.LeftStickX) < -0.5f)
                return ControllerRebinds.ControllerButton.LLeft;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.LeftStickX) > 0.5f)
                return ControllerRebinds.ControllerButton.LRight;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.LeftStickY) > 0.5f)
                return ControllerRebinds.ControllerButton.LUp;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.LeftStickY) < -0.5f)
                return ControllerRebinds.ControllerButton.LDown;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.RightStickX) < -0.5f)
                return ControllerRebinds.ControllerButton.RLeft;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.RightStickX) > 0.5f)
                return ControllerRebinds.ControllerButton.RRight;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.RightStickY) > 0.5f)
                return ControllerRebinds.ControllerButton.RUp;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.RightStickY) < -0.5f)
                return ControllerRebinds.ControllerButton.RDown;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.DpadX) < -0.5f)
                return ControllerRebinds.ControllerButton.DLeft;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.DpadX) > 0.5f)
                return ControllerRebinds.ControllerButton.DRight;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.DpadY) > 0.5f)
                return ControllerRebinds.ControllerButton.DUp;
            if (XboxControllerInput.GetAxis(XboxControllerInput.Axis.DpadY) < -0.5f)
                return ControllerRebinds.ControllerButton.DDown;
            return null;
        }
    }
}
