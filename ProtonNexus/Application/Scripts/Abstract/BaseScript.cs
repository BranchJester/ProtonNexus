using System.Linq;
using System.Windows.Forms;
using GTA;
using ProtonNexus.Application.Managers;
using ProtonNexus.Core.Application.Interfaces;
using Control = System.Windows.Forms.Control;

namespace ProtonNexus.Application.Scripts.Abstract;

public abstract class BaseScript : Script
{
    protected readonly IHotkeysService HotkeysService = ServiceManager.HotkeysService;

    protected bool IsKeyPressed((Keys mainKey, Keys[] modifierKeys) keys)
    {
        // Check if the main key is currently pressed.
        var isMainKeyPressed = Game.IsKeyPressed(keys.mainKey);
        if (!isMainKeyPressed) return false; // If the main key is not pressed, return false.

        // Get the current state of the modifier keys (like Ctrl, Shift, Alt).
        var currentModifiers = Control.ModifierKeys;

        // Check if any required modifier key is not currently pressed.
        if (keys.modifierKeys.Any(key =>
                !currentModifiers.HasFlag(key)))
            return false; // If any required modifier key is not pressed, return false.

        // Define a list of valid modifier keys.
        var validModifiers = new[] { Keys.Control, Keys.Shift, Keys.Alt };

        // Check if all valid modifiers are either not required or currently pressed.
        return validModifiers.All(mod => !currentModifiers.HasFlag(mod) || keys.modifierKeys.Contains(mod));
    }
}