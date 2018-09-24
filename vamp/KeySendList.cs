#region license
/*
Public domain. Free to be used in any purpose.
*/
#endregion

using System.Collections.Generic;
using System.Windows.Forms;

namespace VPKSoft.KeySendList
{
    /// <summary>
    /// Provides aid to the System.Windows.Forms.SendKeys class which provides methods for sending keystrokes to an application.
    /// </summary>
    public static class KeySendList
    {
        // a list of key strokes associated to their string pair for to be used with the Sendkeys.Send() method..
        private static List<KeyValuePair<Keys, string>> keys = new List<KeyValuePair<Keys, string>>();

        /// <summary>
        /// Initializes the <see cref="KeySendList"/> class.
        /// </summary>
        static KeySendList()
        {
            // construct a list of Keys enumeration and string pair values to be used with the Sendkeys.Send() method..
            keys.Add(new KeyValuePair<Keys, string>(Keys.Back, "{BACKSPACE}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Pause, "{BREAK}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.CapsLock, "{CAPSLOCK}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Delete, "{DELETE}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Down, "{DOWN}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.End, "{END}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Return, "{ENTER}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Escape, "{ESC}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Help, "{HELP}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Home, "{HOME}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Insert, "{INSERT}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Left, "{LEFT}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.NumLock, "{NUMLOCK}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.PageDown, "{PGDN}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.PageUp, "{PGUP}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.PrintScreen, "{PRTSC}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Right, "{RIGHT}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Scroll, "{SCROLLLOCK}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Tab, "{TAB}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Up, "{UP}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F1, "{F1}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F2, "{F2}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F3, "{F3}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F4, "{F4}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F5, "{F5}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F6, "{F6}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F7, "{F7}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F8, "{F8}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F9, "{F9}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F10, "{F10}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F11, "{F11}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F12, "{F12}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F13, "{F13}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F14, "{F14}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F15, "{F15}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.F16, "{F16}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Add, "{ADD}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Subtract, "{SUBTRACT}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Multiply, "{MULTIPLY}"));
            keys.Add(new KeyValuePair<Keys, string>(Keys.Divide, "{DIVIDE}"));            
        }

        /// <summary>
        /// Determines whether the specified key has a string value paired with it.
        /// </summary>
        /// <param name="key">The Keys value to check for a string value pair to.</param>
        /// <returns>
        ///   <c>true</c> if the specified key has a string value pair; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasKey(Keys key)
        {
            return GetKeyString(key) != null; // just check as described above..
        }

        /// <summary>
        /// Determines whether the specified string has a Keys enumeration value paired with it.
        /// </summary>
        /// <param name="key">The key's string value to check for a Keys value pair to.</param>
        /// <returns>
        ///   <c>true</c> if the specified string has a Keys enumeration pair; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasKey(string key)
        {
            return GetKeyKeys(key) != null; // just check as described above..
        }

        /// <summary>
        /// Gets the string value for a given Keys enumeration value.
        /// </summary>
        /// <param name="key">A Keys enumeration value.</param>
        /// <returns>A string matching the given Keys enumeration value if found, otherwise null is returned.</returns>
        public static string GetKeyString(Keys key)
        {
            // loop through the key value pairs containing Keys enumeration values 
            // with their string representations for the Sendkeys.Send() method..
            foreach (KeyValuePair<Keys, string> k in keys)
            {
                if (k.Key == key) // if found..
                {
                    return k.Value; // ..return the string value..
                }
            }
            return null; // nothing was found so return null..
        }

        /// <summary>
        /// Gets the Keys enumeration value for a given string value.
        /// </summary>
        /// <param name="key">The string value of the key.</param>
        /// <returns>A Keys enumeration value for a given string value if found, otherwise null is returned.</returns>
        public static Keys? GetKeyKeys(string key)
        {
            // loop through the key value pairs containing Keys enumeration values 
            // with their string representations for the Sendkeys.Send() method..
            foreach (KeyValuePair<Keys, string> k in keys)
            {
                if (k.Value == key) // if found..
                {
                    return k.Key; // ..return the Keys enumeration value..
                }
            }
            return null; // nothing was found so return null..
        }
    }
}
