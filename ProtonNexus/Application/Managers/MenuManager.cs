using LemonUI;
using ProtonNexus.UI.Menus;
using ProtonNexus.UI.Menus.Abstract;

namespace ProtonNexus.Application.Managers;

public static class MenuManager
{
    static MenuManager()
    {
        Pool.Add(MainMenu);
    }

    public static ObjectPool Pool { get; set; } = new();
    public static BaseMenu MainMenu { get; set; } = new MainMenu("Main");
    public static BaseMenu CurrentMenu { get; set; }
    public static BaseMenu LatestMenu { get; set; }
}