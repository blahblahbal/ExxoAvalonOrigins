using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Colossal : ModPrefix
{
    public Colossal()
    {

    }

    public override PrefixCategory Category { get { return PrefixCategory.Melee; } }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Colossal", new Colossal());
    //     }
    //     return false;
    // }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }
    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        scaleMult = 1.5f;
    }
}
