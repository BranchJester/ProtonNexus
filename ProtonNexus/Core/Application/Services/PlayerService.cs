using System;
using ProtonNexus.Core.Application.Interfaces;

namespace ProtonNexus.Core.Application.Services;

public class PlayerService : IPlayerService
{
    private bool _invincible;
    public event Action FixPlayerActivated;
    public event Action<bool> InvincibleChanged;

    public bool Invincible
    {
        get => _invincible;
        set
        {
            if (_invincible == value) return;
            _invincible = value;
            InvincibleChanged?.Invoke(value);
        }
    }

    public void FixPlayer()
    {
        FixPlayerActivated?.Invoke();
    }
}