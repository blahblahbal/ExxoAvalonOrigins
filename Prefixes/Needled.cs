using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Needled : ModPrefix
{
    public Needled()
    {

    }

    public override PrefixCategory Category { get { return PrefixCategory.AnyWeapon; } }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.1f;
    }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Needled", new Needled());
    //     }
    //     return false;
    // }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        damageMult = 1.15f;
    }
}
