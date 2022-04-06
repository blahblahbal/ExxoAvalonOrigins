using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Automated : ModPrefix
{
    public Automated()
    {

    }

    public override PrefixCategory Category => PrefixCategory.Ranged;

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.05f;
    }
    public override bool CanRoll(Item item)
    {
        return true;
    }
    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Automated", new Automated());
    //     }
    //     return false;
    // }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        shootSpeedMult = 1.05f;
    }
}
