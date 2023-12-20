using GTA;
using ProtonNexus.Application.Managers;
using ProtonNexus.Application.Scripts.Abstract;
using ProtonNexus.Core.Application.Interfaces;

namespace ProtonNexus.Application.Scripts.Player;

public class PlayerScript : BaseScript
{
    private readonly IPlayerService _playerService = ServiceManager.PlayerService;

    public PlayerScript()
    {
        _playerService.FixPlayerActivated += FixPlayer;
    }

    private void FixPlayer()
    {
        Game.Player.Character.Health = Game.Player.Character.MaxHealth;
        Game.Player.Character.Armor = Game.Player.MaxArmor;
        Game.Player.RefillSpecialAbility();
    }
}