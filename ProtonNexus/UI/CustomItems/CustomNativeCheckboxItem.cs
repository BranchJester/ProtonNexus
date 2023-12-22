using System;
using LemonUI.Menus;

namespace ProtonNexus.UI.CustomItems;

public class CustomNativeCheckboxItem : NativeCheckboxItem
{
    public CustomNativeCheckboxItem(string name, string description, Action<bool> changedAction = null)
        : base(name, description)
    {
        CheckboxChanged += (_, _) => changedAction?.Invoke(Checked);
    }
}