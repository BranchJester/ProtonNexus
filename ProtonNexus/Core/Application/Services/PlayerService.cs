using System;
using ProtonNexus.Core.Application.Interfaces;

namespace ProtonNexus.Core.Application.Services;

public class PlayerService : IPlayerService
{
    public event Action FixPlayerActivated;

    public void FixPlayer()
    {
        FixPlayerActivated?.Invoke();
    }
}