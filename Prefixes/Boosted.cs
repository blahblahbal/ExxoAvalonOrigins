using Terraria;

namespace ExxoAvalonOrigins.Prefixes;

public class Boosted : ArmorPrefix
{
    public Boosted()
    {

    }

    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.15f;
    }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }
    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Boosted", new Boosted());
    //     }
    //     return false;
    // }
    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.04f;
    }
}
