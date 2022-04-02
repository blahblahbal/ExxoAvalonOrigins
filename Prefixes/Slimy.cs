using Terraria;

namespace ExxoAvalonOrigins.Prefixes;

public class Slimy : ArmorPrefix
{
    public Slimy()
    {

    }

    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Slimy", new Slimy());
    //     }
    //     return false;
    // }
    public override void UpdateEquip(Player player)
    {
        player.endurance += 0.03f;
    }
}
