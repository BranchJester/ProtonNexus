using System;
using System.Windows.Forms;
using ProtonNexus.Constants;
using ProtonNexus.Core.Application.Interfaces;
using ProtonNexus.Core.Domain.Enums;
using ProtonNexus.Core.Domain.Interfaces;
using ProtonNexus.Infrastructure.Repositories;

namespace ProtonNexus.Core.Application.Services;

public class HotkeysService : IHotkeysService
{
    private readonly IHotkeysRepository _hotkeysRepository;

    public HotkeysService()
    {
        _hotkeysRepository = new HotkeysRepository($"{Path.Hotkeys}");
    }

    public (Keys mainKey, Keys[] modifierKeys) GetValue(SectionEnum section, Enum keyName)
    {
        return _hotkeysRepository.GetValue(section, keyName);
    }

    public string GetValueAsString(SectionEnum section, Enum keyName)
    {
        return _hotkeysRepository.GetValueAsString(section, keyName);
    }

    public void SetValue(string section, string keyName, string newKey)
    {
        _hotkeysRepository.SetValue(section, keyName, newKey);
        HotkeyChanged?.Invoke(section, keyName, newKey);
    }

    public event Action<string, string, string> HotkeyChanged;
}