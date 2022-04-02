using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Confused : ArmorPrefix
{
    public Confused()
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
    //         Mod.AddPrefix("Bloated", new Confused());
    //     }
    //     return false;
    // }
    public override void UpdateEquip(Player player)
    {
        player.GetDamage<MeleeDamageClass>() += 0.05f;
        player.meleeSpeed -= 0.02f;
    }
}
