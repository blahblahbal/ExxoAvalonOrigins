using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Enchanted : ModPrefix
{
    public Enchanted()
    {

    }

    public override PrefixCategory Category => PrefixCategory.Accessory;

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.25f;
    }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }
    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Enchanted", new Enchanted());
    //     }
    //     return false;
    // }

    public override void Apply(Item item)
    {
        Main.player[Main.myPlayer].statManaMax2 += 20;
        Main.player[Main.myPlayer].moveSpeed += 0.03f;
        Main.player[Main.myPlayer].statDefense++;
    }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
    }
}
