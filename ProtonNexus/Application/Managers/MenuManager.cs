using System;
using LemonUI;
using ProtonNexus.UI.Menus;
using ProtonNexus.UI.Menus.Abstract;
using ProtonNexus.UI.Menus.Player;

namespace ProtonNexus.Application.Managers;

public static class MenuManager
{
    static MenuManager()
    {
        Initialize();
    }

    public static ObjectPool Pool { get; private set; }
    public static BaseMenu MainMenu { get; private set; }
    public static BaseMenu PlayerMenu { get; private set; }
    public static BaseMenu CurrentMenu { get; set; }
    public static BaseMenu LatestMenu { get; set; }

    public static event Action OnMenuInitialized;

    private static void Initialize()
    {
        Pool = new ObjectPool();
        MainMenu = new MainMenu("Main");
        PlayerMenu = new PlayerMenu("Player");
        Pool.Add(MainMenu);
        Pool.Add(PlayerMenu);

        // Once all menus are initialized, invoke the event.
        OnMenuInitialized?.Invoke();
    }
}