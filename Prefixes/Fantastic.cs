using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Fantastic : ModPrefix
{
    public Fantastic()
    {

    }

    public override PrefixCategory Category { get { return PrefixCategory.Ranged; } }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Fantastic", new Fantastic());
    //     }
    //     return false;
    // }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }
    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        knockbackMult = 1.2f;
        damageMult = 1.2f;
        critBonus = 6;
        shootSpeedMult = 1.13f;
        useTimeMult = 0.85f;
    }
}
