using System.Windows.Forms;
using GTA.UI;
using ProtonNexus.Application.Scripts.Abstract;
using ProtonNexus.Core.Domain.Enums;

namespace ProtonNexus.Application.Scripts;

/// <summary>
///     This script is considered the main script. This script is responsible,
///     for loading the menu.
/// </summary>
public class MainScript : BaseScript
{
    public MainScript()
    {
        KeyDown += OnkeyDown;
    }

    private void OnkeyDown(object sender, KeyEventArgs e)
    {
        var testKey = HotkeysService.GetValue(SectionEnum.Menu, MenuEnum.Toggle);
        if (IsKeyPressed(testKey)) Notification.Show("HELLO WORLD!");
    }
}