using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Hectic : ModPrefix
{
    public Hectic()
    {

    }

    public override PrefixCategory Category { get { return PrefixCategory.Magic; } }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.05f;
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Hectic", new Hectic());
    //     }
    //     return false;
    // }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        knockbackMult = 0.93f;
        damageMult = 0.95f;
        critBonus = -1;
        useTimeMult = 0.83f;
        manaMult = 1.03f;
    }
}
