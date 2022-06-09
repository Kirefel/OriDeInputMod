using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace OriDeInputMod
{
    public class CustomKeyRebindings
    {
        private static KeyboardBindingSettings keyboardRebindings;
        private const string CustomKeyboardInputRebindingsFileName = "CustomKeyRebindings.txt";
        private static string KeyboardRebindingFile => Path.Combine(OutputFolder.PlayerDataFolderPath, CustomKeyboardInputRebindingsFileName);

        public static KeyboardBindingSettings KeyRebindings
        {
            get
            {
                if (keyboardRebindings == null)
                {
                    if (!File.Exists(CustomKeyboardInputRebindingsFileName))
                    {
                        SetDefaultKeyboardBindingSettings();
                        WriteKeyboardRebindSettings();
                    }
                    else
                    {
                        GetKeyboardRebindSettingsFromFile();
                    }
                }
                return keyboardRebindings;
            }
        }

        private static void GetKeyboardRebindSettingsFromFile()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(new FileStream(KeyboardRebindingFile, FileMode.Open)))
                {
                    streamReader.ReadLine();
                    streamReader.ReadLine();
                    keyboardRebindings = new KeyboardBindingSettings
                    {
                        Stomp = StringToKeyBinding(streamReader.ReadLine())
                    };
                }
            }
            catch (Exception ex)
            {
                OriDeModLoader.EntryPoint.Log("Failed to read " + CustomKeyboardInputRebindingsFileName);
                OriDeModLoader.EntryPoint.Log(ex.ToString());
                SetDefaultKeyboardBindingSettings();
            }
        }

        private static void WriteKeyboardRebindSettings()
        {
            using (StreamWriter streamWriter = new StreamWriter(new FileStream(KeyboardRebindingFile, FileMode.OpenOrCreate)))
            {
                KeyboardBindingSettings binds = keyboardRebindings;
                streamWriter.WriteLine("Key Rebindings");
                streamWriter.WriteLine("--------");
                streamWriter.WriteLine("Stomp: " + KeyBindingToString(binds.Stomp));
                streamWriter.WriteLine("--------");
                streamWriter.WriteLine("Usage:");
                streamWriter.WriteLine("- There is no guarantee of the game still being playable after key rebinding. Please use with caution and delete this file in case of breakage");
                streamWriter.WriteLine("- Spelling and syntactical errors will result in the key rebindings not registering properly, and the game will get set to default");
                streamWriter.WriteLine("- Deleting this file will result in this file being recreated by the game, containing the default settings");
                streamWriter.WriteLine("--------");
                streamWriter.WriteLine("Don't forget to restart the game after editing this file!");
                streamWriter.WriteLine("Don't forget to close this file before restarting the game!");
                streamWriter.WriteLine("--------");
            }
        }

        private static KeyCode[] StringToKeyBinding(string s)
        {
            s = s.Split(new string[]
            {
            ": "
            }, StringSplitOptions.None)[1];
            string[] array = s.Split(new string[]
            {
            ", "
            }, StringSplitOptions.None);
            List<KeyCode> list = new List<KeyCode>();
            string[] array2 = array;
            for (int i = 0; i < array2.Length; i++)
            {
                string value = array2[i];
                list.Add((KeyCode)((int)Enum.Parse(typeof(KeyCode), value)));
            }
            return list.ToArray();
        }

        private static string KeyBindingToString(KeyCode[] codes)
        {
            string text = string.Empty;
            bool flag = true;
            for (int i = 0; i < codes.Length; i++)
            {
                KeyCode keyCode = codes[i];
                text += ((!flag) ? ", " : string.Empty);
                text += keyCode;
                flag = false;
            }
            return text;
        }

        private static void SetDefaultKeyboardBindingSettings()
        {
            keyboardRebindings = new KeyboardBindingSettings();
        }

        public class KeyboardBindingSettings
        {
            public KeyCode[] Stomp = new KeyCode[] { KeyCode.S };
        }
    }
}
