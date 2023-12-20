using ProtonNexus.Application.Managers;
using ProtonNexus.UI.Menus.Abstract;

namespace ProtonNexus.UI.Menus;

public class MainMenu : BaseMenu
{
    public MainMenu(string menuName) : base(menuName)
    {
    }

    protected override void InitializeItems()
    {
        AddSubMenu(MenuManager.PlayerMenu, "Menu");
    }
}