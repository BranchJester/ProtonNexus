namespace ProtonNexus.UI.Menus.Strategies;

public class CustomNativeItemDescriptionStrategy : IItemDescriptionStrategy
{
    public string UpdateDescription(string baseDescription, string hotkey)
    {
        return string.IsNullOrEmpty(hotkey)
            ? $"{baseDescription}\n\n~y~Hotkey not set."
            : $"{baseDescription}\n\n~y~Press ~s~{hotkey.Replace(" ", "")}~y~ to activate.";
    }
}