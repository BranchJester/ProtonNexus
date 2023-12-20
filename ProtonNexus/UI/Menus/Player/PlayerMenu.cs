using GTA.UI;
using LemonUI.Menus;
using ProtonNexus.Application.Extensions;
using ProtonNexus.Application.Managers;
using ProtonNexus.Core.Application.Interfaces;
using ProtonNexus.Core.Domain.Enums;
using ProtonNexus.UI.Menus.Abstract;

namespace ProtonNexus.UI.Menus.Player;

public class PlayerMenu : BaseMenu
{
    private readonly IPlayerService _playerService = ServiceManager.PlayerService;
    public PlayerMenu(string menuName) : base(menuName)
    {
    }

    protected override void InitializeItems()
    {
        FixPlayer();
    }

    private void FixPlayer()
    {
        var fixPlayer = new NativeItem(PlayerEnum.FixPlayer.ToPrettyString(), PlayerEnum.FixPlayer.GetDescription());
        fixPlayer.Activated += (sender, args) =>
        {
            _playerService.FixPlayer();
        };
        _playerService.FixPlayerActivated += () =>
        {
            Notification.Show("Player fixed!");
        };
        Add(fixPlayer);
    }
}