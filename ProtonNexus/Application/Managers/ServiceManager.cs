using ProtonNexus.Core.Application.Interfaces;
using ProtonNexus.Core.Application.Services;

namespace ProtonNexus.Application.Managers;

public static class ServiceManager
{
    public static IHotkeysService HotkeysService { get; set; } = new HotkeysService();
    public static IPlayerService PlayerService { get; set; } = new PlayerService();
}