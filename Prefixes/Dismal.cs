using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Dismal : ModPrefix
{
    public Dismal()
    {

    }

    public override bool CanRoll(Item item)
    {
        return false;
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Dismal", new Dismal());
    //     }
    //     return false;
    // }
    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        damageMult = 0.6f;
    }
}
