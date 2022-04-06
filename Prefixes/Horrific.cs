using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Horrific : ModPrefix
{
    public Horrific()
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
    //         Mod.AddPrefix("Horrific", new Horrific());
    //     }
    //     return false;
    // }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        knockbackMult = 1.1f;
        damageMult = 0.9f;
        critBonus = -3;
        shootSpeedMult = 0.9f;
    }
}
