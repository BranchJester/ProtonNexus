using System;
using System.Drawing;
using LemonUI.Menus;
using LemonUI.Scaleform;
using ProtonNexus.Application.Extensions;
using ProtonNexus.Application.Managers;
using ProtonNexus.Core.Application.Interfaces;
using ProtonNexus.UI.Menus.Strategies;

namespace ProtonNexus.UI.Menus.Abstract;

public abstract class BaseMenu : NativeMenu
{
    protected readonly IHotkeysService HotkeysService = ServiceManager.HotkeysService;
    protected readonly ItemFactory ItemFactory = new();

    protected BaseMenu(string menuName) : base("Proton Nexus", menuName)
    {
        MenuName = menuName;
        Banner.Color = Color.FromArgb(255, 0, 0, 0);
        var usageInstructionalButton = new InstructionalButton("Change Usage Hotkey: PageDown", "");
        Buttons.Add(usageInstructionalButton);

        var activationInstructionalButton = new InstructionalButton("Change Activation Hotkey: PageUp", "");
        Buttons.Add(activationInstructionalButton);

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
                var descriptionStrategy = item is NativeCheckboxItem
                    ? (IItemDescriptionStrategy)new CustomNativeCheckboxItemDescriptionStrategy()
                    : new CustomNativeItemDescriptionStrategy();

                item.Description = descriptionStrategy.UpdateDescription(
                    item.Description.Split(new[] { "\n\n" }, StringSplitOptions.None)[0],
                    newKey
                );
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