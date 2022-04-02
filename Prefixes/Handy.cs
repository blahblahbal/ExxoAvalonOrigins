using Terraria;

namespace ExxoAvalonOrigins.Prefixes;

public class Handy : ArmorPrefix
{
    public Handy()
    {

    }

    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.2f;
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Handy", new Handy());
    //     }
    //     return false;
    // }
    public override void UpdateEquip(Player player)
    {
        player.blockRange++;
    }
}
