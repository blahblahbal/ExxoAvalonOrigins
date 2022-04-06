using Terraria;

namespace ExxoAvalonOrigins.Prefixes;

public class Fluidic : ArmorPrefix
{
    public Fluidic()
    {

    }

    public override bool CanRoll(Item item)
    {
        return IsArmor(item);
    }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }
    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.25f;
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Fluidic", new Fluidic());
    //     }
    //     return false;
    // }
    public override void UpdateEquip(Player player)
    {
        player.moveSpeed += 0.05f;
        player.ignoreWater = true;
    }
}
