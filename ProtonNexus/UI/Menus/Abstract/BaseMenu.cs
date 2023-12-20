using System;
using System.Drawing;
using GTA;
using LemonUI.Menus;
using LemonUI.Scaleform;
using ProtonNexus.Application.Extensions;
using ProtonNexus.Application.Managers;
using ProtonNexus.Core.Application.Interfaces;

namespace ProtonNexus.UI.Menus.Abstract;

public abstract class BaseMenu : NativeMenu
{
    protected readonly IHotkeysService HotkeysService = ServiceManager.HotkeysService;

    protected BaseMenu(string menuName) : base("Proton Nexus", menuName)
    {
        MenuName = menuName;
        Banner.Color = Color.FromArgb(255, 0, 0, 0);
        var instructionalButton = new InstructionalButton("Change Hotkey", Control.SelectWeapon);
        Buttons.Add(instructionalButton);

        Shown += OnShown;
        Closed += OnClosed;
        HotkeysService.HotkeyChanged += OnHotkeyChanged;

        // This is called when the menu manager has created all menus.
        MenuManager.OnMenuInitialized += InitializeItems;
    }

    protected string MenuName { get; set; }

    /// <summary>
    ///     Initializes the items of the menu.
    /// </summary>
    protected abstract void InitializeItems();

    private void OnHotkeyChanged(string section, string keyName, string newKey)
    {
        foreach (var item in Items)
        {
            if (item.Title.ToEnumStyle() == keyName)
            {
                // Split the description at the hotkey-line and replace the hotkey
                var descriptionParts = item.Description.Split(new[] { "\n\n~g~Hotkey:" }, StringSplitOptions.None);
                if (descriptionParts.Length >= 2)
                    item.Description = $"{descriptionParts[0]}\n\n~g~Hotkey: {newKey}";
            }
        }
    }

    private void OnClosed(object sender, EventArgs e)
    {
        MenuManager.CurrentMenu = null;
    }

    private void OnShown(object sender, EventArgs e)
    {
        MenuManager.LatestMenu = this;
        MenuManager.CurrentMenu = this;
    }
}