using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace Echo.Input
{
    [JsonConverter(typeof(StringEnumConverter))]
    public static class KeyMapping
    {
        private static string path;

        private static JObject keys;
        private static Dictionary<string, Key> keyList = new Dictionary<string, Key>();

        static KeyMapping()
        {
            Loader.UseEnginePath();
            path = Loader.Asset + @"\Config\Keymapping.json";
            string file = File.ReadAllText(path);
            Log.Info(file);
            keys = JObject.Parse(File.ReadAllText(path));
        }

        public static event EventHandler<Dictionary<string, Key>> UpdateKeyMappingEventHandler;

        /// <summary>
        /// called when the key mapping is changed
        /// telling every class use it's keymapping to change
        /// </summary>
        public static void UpdateKeyMapping()
        {
            keys = JObject.Parse(File.ReadAllText(path));

            //convert all tokens into keys
            foreach (var k in keys)
            {
                keyList.Add(k.Key, (Key)ToEnumKey(k.Value));
            }

            UpdateKeyMappingEventHandler?.Invoke(null, keyList);
        }

        /// <summary>
        /// bc keymapping sucks
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static int ToEnumKey(in JToken val)
        {
            string key = val.ToString();
            Log.Info(key);
            switch (key)
            {
                case "Left Shift": return 1;
                case "Right Shift": return 2;
                case "Left Control": return 3;
                case "Right Control": return 4;
                case "Left Alt": return 5;
                case "Right Alt": return 6;
                case "Left Win": return 7;
                case "Right Win": return 8;
                case "Menu": return 9;
                case "F1": return 10;
                case "F2": return 11;
                case "F3": return 12;
                case "F4": return 13;
                case "F5": return 14;
                case "F6": return 15;
                case "F7": return 16;
                case "F8": return 17;
                case "F9": return 18;
                case "F10": return 19;
                case "F11": return 20;
                case "F12": return 21;
                case "F13": return 22;
                case "F14": return 23;
                case "F15": return 24;
                case "F16": return 25;
                case "F17": return 26;
                case "F18": return 27;
                case "F19": return 28;
                case "F20": return 29;
                case "F21": return 30;
                case "F22": return 31;
                case "F23": return 32;
                case "F24": return 33;
                case "F25": return 34;
                case "F26": return 35;
                case "F27": return 36;
                case "F28": return 37;
                case "F29": return 38;
                case "F30": return 39;
                case "F31": return 40;
                case "F32": return 41;
                case "F33": return 42;
                case "F34": return 43;
                case "F35": return 44;
                case "Up": return 45;
                case "Down": return 46;
                case "Left": return 47;
                case "Right": return 48;
                case "Enter": return 49;
                case "Escape": return 50;
                case "Space": return 51;
                case "Tab": return 52;
                case "BackSpace": return 53;
                case "Insert": return 54;
                case "Delete": return 55;
                case "Page Up": return 56;
                case "Page Down": return 57;
                case "Home": return 58;
                case "End": return 59;
                case "Caps Lock": return 60;
                case "Scroll Lock": return 61;
                case "Print Screen": return 62;
                case "Pause": return 63;
                case "Num Lock": return 64;
                case "Clear": return 65;
                case "Sleep": return 66;
                case "Keypad 0": return 67;
                case "Keypad 1": return 68;
                case "Keypad 2": return 69;
                case "Keypad 3": return 70;
                case "Keypad 4": return 71;
                case "Keypad 5": return 72;
                case "Keypad 6": return 73;
                case "Keypad 7": return 74;
                case "Keypad 8": return 75;
                case "Keypad 9": return 76;
                case "Keypad /": return 77;
                case "Keypad *": return 78;
                case "Keypad -": return 79;
                case "Keypad +": return 80;
                case "Keypad ,": return 81;
                case "Keypad Enter": return 82;
                case "A": return 83;
                case "B": return 84;
                case "C": return 85;
                case "D": return 86;
                case "E": return 87;
                case "F": return 88;
                case "G": return 89;
                case "H": return 90;
                case "I": return 91;
                case "J": return 92;
                case "K": return 93;
                case "L": return 94;
                case "M": return 95;
                case "N": return 96;
                case "O": return 97;
                case "P": return 98;
                case "Q": return 99;
                case "R": return 100;
                case "S": return 101;
                case "T": return 102;
                case "U": return 103;
                case "V": return 104;
                case "W": return 105;
                case "X": return 106;
                case "Y": return 107;
                case "Z": return 108;
                case "0": return 109;
                case "1": return 110;
                case "2": return 111;
                case "3": return 112;
                case "4": return 113;
                case "5": return 114;
                case "6": return 115;
                case "7": return 116;
                case "8": return 117;
                case "9": return 118;
                case "~": return 119;
                case "`": return 119;
                case "-": return 120;
                case "+": return 121;
                case "{": return 122;
                case "}": return 123;
                case ";": return 124;
                case "\"": return 125;
                case ",": return 126;
                case ".": return 127;
                case "/": return 128;
                case "\\": return 129;
                case "NonUSBackSlash": return 130;
                case "LastKey": return 131;
                case "Command": return 132;
                default: return 0;
            }
        }
    }
}