using System;
using System.Collections.Generic;
using BaseModLib;
using OriDeModLoader.UIExtensions;
using SmartInput;
using UnityEngine;

namespace OriDeInputMod
{
    public class KeybindControl : MonoBehaviour
    {
        private void Awake()
        {
            messageBox = base.transform.Find("text/stateText").GetComponent<MessageBox>();
        }

        public void BeginEditing()
        {
            currentKeys.Clear();
            currentKeys.AddRange(GetKeys());
            SuspensionManager.SuspendAll();
            editing = true;
            exit = 0;
            tooltipProvider.SetMessage("Backspace: remove bind\nEnter: finish editing");
            owner.tooltipController.UpdateTooltip();
        }

        public void Update()
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
            if (Input.GetKeyDown(KeyCode.Return) && currentKeys.Count > 0)
            {
                editing = false;
                SuspensionManager.ResumeAll();
                SetKeys(currentKeys.ToArray());
                PlayerInputRebinding.WriteKeyRebindSettings();
                PlayerInput.Instance.RefreshControlScheme();
                tooltipProvider.SetMessage("Click on an action to add or remove binds");
                owner.tooltipController.UpdateTooltip();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                if (currentKeys.Count > 0)
                {
                    currentKeys.RemoveAt(currentKeys.Count - 1);
                    UpdateMessageBox();
                    return;
                }
            }
            else if (Input.anyKeyDown)
            {
                foreach (object obj in Enum.GetValues(typeof(KeyCode)))
                {
                    KeyCode keyCode = (KeyCode)obj;
                    if (Input.GetKeyDown(keyCode) && !currentKeys.Contains(keyCode))
                    {
                        currentKeys.Add(keyCode);
                        UpdateMessageBox();
                    }
                }
            }
        }

        private void UpdateMessageBox()
        {
            messageBox.SetMessage(new MessageDescriptor(KeybindControl.KeyBindingToString(currentKeys.ToArray())));
        }

        public static string KeyBindingToString(KeyCode[] codes)
        {
            string text = string.Empty;
            bool flag = true;
            foreach (KeyCode keyCode in codes)
            {
                text += ((!flag) ? ", " : string.Empty);
                text += keyCode.KeyCodeToButtonIcon();
                flag = false;
            }
            return text;
        }

        public void Reset()
        {
            messageBox.SetMessage(new MessageDescriptor(KeybindControl.KeyBindingToString(GetKeys())));
            editing = false;
        }

        public void Init(Func<KeyCode[]> getKeys, Action<KeyCode[]> setKeys, CustomOptionsScreen owner)
        {
            this.owner = owner;
            GetKeys = getKeys;
            SetKeys = setKeys;
            messageBox.SetMessage(new MessageDescriptor(KeybindControl.KeyBindingToString(getKeys())));
            CleverMenuItemTooltip component = base.GetComponent<CleverMenuItemTooltip>();
            tooltipProvider = ScriptableObject.CreateInstance<BasicMessageProvider>();
            tooltipProvider.SetMessage("Click on an action to add or remove binds");
            component.Tooltip = tooltipProvider;
            owner.tooltipController.UpdateTooltip();
        }

        private Func<KeyCode[]> GetKeys;

        private Action<KeyCode[]> SetKeys;

        private bool editing;

        private MessageBox messageBox;

        private readonly List<KeyCode> currentKeys = new List<KeyCode>();

        private int exit;

        private CustomOptionsScreen owner;

        private BasicMessageProvider tooltipProvider;
    }
}
