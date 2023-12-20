using System;
using System.Windows.Forms;
using ProtonNexus.Application.Managers;
using ProtonNexus.Application.Scripts.Abstract;
using ProtonNexus.Core.Domain.Enums;
using ProtonNexus.UI.Menus.Abstract;

namespace ProtonNexus.Application.Scripts;

/// <summary>
///     This script is considered the main script. This script is responsible,
///     for loading the menu.
/// </summary>
public class MainScript : BaseScript
{
    private readonly BaseMenu _mainMenu;

    public MainScript()
    {
        _mainMenu = MenuManager.MainMenu;

        Tick += OnTick;
        KeyDown += OnKeyDown;
    }

    private void OnTick(object sender, EventArgs e)
    {
        MenuManager.Pool.Process();
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        var menuKey = HotkeysService.GetValue(SectionEnum.Menu, MenuEnum.Toggle);
        if (IsKeyPressed(menuKey))
        {
            var latestMenu = MenuManager.LatestMenu;
            if (latestMenu == null)
                _mainMenu.Visible = !_mainMenu.Visible;
            else
                latestMenu.Visible = !latestMenu.Visible;
        }
    }
}