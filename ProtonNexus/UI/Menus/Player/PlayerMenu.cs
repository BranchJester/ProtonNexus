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
        Invincible();
    }

    private void Invincible()
    {
        var invincible = ItemFactory.CreateCheckboxItem(PlayerEnum.Invincible, SectionEnum.Player,
            state => { _playerService.Invincible = state; });
        Add(invincible);
    }

    private void FixPlayer()
    {
        var fixPlayer = ItemFactory.CreateItem(PlayerEnum.FixPlayer, SectionEnum.Player,
            () => { _playerService.FixPlayer(); });
        Add(fixPlayer);
    }
}