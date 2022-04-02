using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Barbaric : ArmorPrefix
{
    public Barbaric()
    {

    }

    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.25f;
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Barbaric", new Barbaric());
    //     }
    //     return false;
    // }
    public override void UpdateEquip(Player player)
    {
        player.GetDamage<GenericDamageClass>() += 0.04f;
        player.Avalon().bonusKB = 1.06f;
        //player.inventory[player.selectedItem].knockBack += 0.06f;
    }
}
