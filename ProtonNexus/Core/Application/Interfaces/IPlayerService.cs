using System;

namespace ProtonNexus.Core.Application.Interfaces;

public interface IPlayerService
{
    event Action FixPlayerActivated;
    void FixPlayer();
}