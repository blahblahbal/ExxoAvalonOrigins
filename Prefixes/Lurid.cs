using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Lurid : ModPrefix
{
    public Lurid()
    {

    }

    public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.25f;
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Lurid", new Lurid());
    //     }
    //     return false;
    // }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }
    public override void Apply(Item item)
    {
        Main.player[Main.myPlayer].GetCritChance(DamageClass.Magic) += 2;
        Main.player[Main.myPlayer].GetCritChance(DamageClass.Melee) += 2;
        Main.player[Main.myPlayer].GetCritChance(DamageClass.Ranged) += 2;
        Main.player[Main.myPlayer].statDefense += 2;
    }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
    }
}
