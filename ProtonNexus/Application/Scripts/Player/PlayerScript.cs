using System;
using System.Windows.Forms;
using GTA;
using ProtonNexus.Application.Managers;
using ProtonNexus.Application.Scripts.Abstract;
using ProtonNexus.Core.Application.Interfaces;
using ProtonNexus.Core.Domain.Enums;

namespace ProtonNexus.Application.Scripts.Player;

public class PlayerScript : BaseScript
{
    private readonly IPlayerService _playerService = ServiceManager.PlayerService;

    public PlayerScript()
    {
        _playerService.FixPlayerActivated += FixPlayer;

        Tick += OnTick;
        KeyDown += OnKeyDown;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        var fixPlayerKey = HotkeysService.GetValue(SectionEnum.Player, PlayerEnum.FixPlayer);
        if (IsKeyPressed(fixPlayerKey)) _playerService.FixPlayer();
    }

    private void OnTick(object sender, EventArgs e)
    {
    }

    private void FixPlayer()
    {
        Game.Player.Character.Health = Game.Player.Character.MaxHealth;
        Game.Player.Character.Armor = Game.Player.MaxArmor;
        Game.Player.RefillSpecialAbility();
    }
}