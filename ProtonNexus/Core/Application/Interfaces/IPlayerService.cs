using System;

namespace ProtonNexus.Core.Application.Interfaces;

public interface IPlayerService
{
    bool Invincible { get; set; }
    event Action<bool> InvincibleChanged;

    /// <summary>
    ///     This event is raised when the player is fixed.
    /// </summary>
    event Action FixPlayerActivated;

    /// <summary>
    ///     Fixes the player by raising the <see cref="FixPlayerActivated" /> event.
    /// </summary>
    void FixPlayer();
}