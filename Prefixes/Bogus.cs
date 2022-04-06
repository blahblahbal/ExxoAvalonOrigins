using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Bogus : ModPrefix
{
    public Bogus()
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
    //         Mod.AddPrefix("Bogus", new Bogus());
    //     }
    //     return false;
    // }

    public override void Apply(Item item)
    {
        Main.player[Main.myPlayer].GetCritChance(DamageClass.Magic) += 5;
        Main.player[Main.myPlayer].GetCritChance(DamageClass.Melee) += 5;
        Main.player[Main.myPlayer].GetCritChance(DamageClass.Ranged) += 5;
        Main.player[Main.myPlayer].GetCritChance(DamageClass.Throwing) += 5;
    }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
    }
}
