using System;
using LemonUI.Menus;

namespace ProtonNexus.UI.CustomItems;

public class CustomNativeItem : NativeItem
{
    public CustomNativeItem(string name, string description, Action activationAction = null)
        : base(name, description)
    {
        Activated += (sender, args) => activationAction?.Invoke();
    }
}