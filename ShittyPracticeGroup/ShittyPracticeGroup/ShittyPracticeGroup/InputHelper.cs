using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ShittyPracticeGroup
{
    /// <summary>
    /// This class is used to help capture and map the user's input.
    /// It does NOT actually handle the input, just prepares it for handling.
    /// </summary>
    public class InputHelper
    {
        /// <summary>
        /// Contains a list of
        /// </summary>
        private Dictionary<Keys, ActionType> keysToActionMap;
        public Dictionary<Keys, ActionType> KeysToActionMap
        {
            get
            {
                if (keysToActionMap == null)
                {
                    keysToActionMap = new Dictionary<Keys, ActionType>();
                }

                return keysToActionMap;
            }
        }

        /// <summary>
        /// default input handler
        /// </summary>
        public InputHelper()
        {
            RestoreDefaultKeyMapping();
        }

        /// <summary>
        /// Initializes (and later restores) the default kep mapping
        /// </summary>
        public void RestoreDefaultKeyMapping()
        {
            keysToActionMap = new Dictionary<Keys, ActionType>();
            keysToActionMap.Add(Keys.W, ActionType.MoveUp);
            keysToActionMap.Add(Keys.A, ActionType.MoveLeft);
            keysToActionMap.Add(Keys.S, ActionType.MoveDown);
            keysToActionMap.Add(Keys.D, ActionType.MoveRight);
            keysToActionMap.Add(Keys.Space, ActionType.SwordAttack);
        }

        /// <summary>
        /// Inspects the currently pressed keys and compiles a list of action types that
        /// have been requested based on the current mapping.
        /// </summary>
        /// <returns></returns>
        public IList<ActionType> GetRequestedActions()
        {
            IList<ActionType> actions = new List<ActionType>();
            KeyboardState keyState = Keyboard.GetState();

            Keys[] keysPressed = keyState.GetPressedKeys();

            foreach (Keys key in keysPressed)
            {
                if(keysToActionMap.ContainsKey(key))
                {
                    actions.Add(keysToActionMap[key]);
                }
            }

            return actions;
        }
    }
}
