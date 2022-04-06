using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Woozy : ModPrefix
{
    public Woozy()
    {

    }

    public override PrefixCategory Category { get { return PrefixCategory.Ranged; } }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 0.9f;
    }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }
    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Woozy", new Woozy());
    //     }
    //     return false;
    // }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        damageMult = 1.05f;
        shootSpeedMult = 0.93f;
        useTimeMult = 1.12f;
    }
}
