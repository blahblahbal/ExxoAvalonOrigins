using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Systems;

public class KeybindSystem : ModSystem
{
    public static ModKeybind ShadowHotkey { get; private set; }
    public static ModKeybind SprintHotkey { get; private set; }
    public static ModKeybind DashHotkey { get; private set; }
    public static ModKeybind QuintupleHotkey { get; private set; }
    public static ModKeybind SwimHotkey { get; private set; }
    public static ModKeybind WallSlideHotkey { get; private set; }
    public static ModKeybind BubbleBoostHotkey { get; private set; }
    public static ModKeybind ModeChangeHotkey { get; private set; }
    public static ModKeybind AstralHotkey { get; private set; }
    public static ModKeybind RocketJumpHotkey { get; private set; }
    public static ModKeybind QuickStaminaHotkey { get; private set; }
    public static ModKeybind FlightTimeRestoreHotkey { get; private set; }
    public static ModKeybind MinionGuidingHotkey { get; private set; }

    public override void Load()
    {
        ShadowHotkey = KeybindLoader.RegisterKeybind(Mod, "Shadow Teleport", "V");
        SprintHotkey = KeybindLoader.RegisterKeybind(Mod, "Stamina Sprint", "F");
        DashHotkey = KeybindLoader.RegisterKeybind(Mod, "Stamina Dash", "K");
        QuintupleHotkey = KeybindLoader.RegisterKeybind(Mod, "Toggle Quintuple Jump", "RightControl");
        SwimHotkey = KeybindLoader.RegisterKeybind(Mod, "Stamina Swimming", "L");
        WallSlideHotkey = KeybindLoader.RegisterKeybind(Mod, "Stamina Wall Sliding", "Z");
        BubbleBoostHotkey = KeybindLoader.RegisterKeybind(Mod, "Toggle Bubble Boost", "U");
        ModeChangeHotkey = KeybindLoader.RegisterKeybind(Mod, "Mode Change", "N");
        AstralHotkey = KeybindLoader.RegisterKeybind(Mod, "Activate Astral Projecting", "OemPipe");
        RocketJumpHotkey = KeybindLoader.RegisterKeybind(Mod, "Stamina Rocket Jump", "C");
        QuickStaminaHotkey = KeybindLoader.RegisterKeybind(Mod, "Quick Stamina", "X");
        FlightTimeRestoreHotkey = KeybindLoader.RegisterKeybind(Mod, "Stamina Flight Time Restore", "G");
    }
    public override void Unload()
    {
        ShadowHotkey = null;
        SprintHotkey = null;
        DashHotkey = null;
        QuintupleHotkey = null;
        SwimHotkey = null;
        WallSlideHotkey = null;
        BubbleBoostHotkey = null;
        ModeChangeHotkey = null;
        AstralHotkey = null;
        RocketJumpHotkey = null;
        QuickStaminaHotkey = null;
        FlightTimeRestoreHotkey = null;
    }
}
