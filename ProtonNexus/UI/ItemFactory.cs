using System;
using ProtonNexus.Application.Extensions;
using ProtonNexus.Application.Managers;
using ProtonNexus.Core.Application.Interfaces;
using ProtonNexus.Core.Domain.Enums;
using ProtonNexus.UI.CustomItems;
using ProtonNexus.UI.Menus.Strategies;

namespace ProtonNexus.UI;

public class ItemFactory
{
    private readonly IHotkeysService _hotkeysService = ServiceManager.HotkeysService;

    public CustomNativeItem CreateItem(Enum @enum, SectionEnum hotKeySectionEnum,
        Action activationAction = null)
    {
        var prettyName = @enum.ToPrettyString();
        var description = @enum.GetDescription();
        var activationHotkey = _hotkeysService.GetValueAsString(hotKeySectionEnum, @enum);

        var itemDescriptionStrategy = new CustomNativeItemDescriptionStrategy();
        description = itemDescriptionStrategy.UpdateDescription(description, activationHotkey);

        return new CustomNativeItem(prettyName, description, activationAction);
    }

    public CustomNativeCheckboxItem CreateCheckboxItem(Enum @enum, SectionEnum hotKeySectionEnum,
        Action<bool> changedAction = null)
    {
        var prettyName = @enum.ToPrettyString();
        var description = @enum.GetDescription();
        var activationHotkey = _hotkeysService.GetValueAsString(hotKeySectionEnum, @enum);

        var itemDescriptionStrategy = new CustomNativeCheckboxItemDescriptionStrategy();
        description = itemDescriptionStrategy.UpdateDescription(description, activationHotkey);

        var checkboxItem = new CustomNativeCheckboxItem(prettyName, description, changedAction);

        return checkboxItem;
    }
}