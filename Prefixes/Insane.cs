using Terraria;

namespace ExxoAvalonOrigins.Prefixes;

public class Insane : ArmorPrefix
{
    public Insane()
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
    //         Mod.AddPrefix("Insane", new Insane());
    //     }
    //     return false;
    // }
    public override void UpdateEquip(Player player)
    {
        player.tileSpeed += 0.3f;
        player.wallSpeed += 0.3f;
    }
}
