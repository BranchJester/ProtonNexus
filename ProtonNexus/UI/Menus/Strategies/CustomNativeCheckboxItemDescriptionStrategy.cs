namespace ProtonNexus.UI.Menus.Strategies;

public class CustomNativeCheckboxItemDescriptionStrategy : IItemDescriptionStrategy
{
    public string UpdateDescription(string baseDescription, string hotkey)
    {
        return string.IsNullOrEmpty(hotkey)
            ? $"{baseDescription}\n\n~y~Hotkey not set."
            : $"{baseDescription}\n\n~y~Toggle with ~s~{hotkey.Replace(" ", "")}~y~.";
    }
}