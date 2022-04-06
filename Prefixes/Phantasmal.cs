using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Phantasmal : ModPrefix
{
    public Phantasmal()
    {

    }

    public override PrefixCategory Category { get { return PrefixCategory.Magic; } }

    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        knockbackMult = 1.2f;
        damageMult = 1.19f;
        critBonus = 6;
        useTimeMult = 0.85f;
        manaMult = 0.85f;
    }
}
