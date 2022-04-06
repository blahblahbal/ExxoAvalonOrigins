using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Perfect : ModPrefix
{
    public Perfect()
    {

    }

    public override PrefixCategory Category => PrefixCategory.AnyWeapon;

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.25f;
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Perfect", new Perfect());
    //     }
    //     return false;
    // }
    public override bool CanRoll(Terraria.Item item)
    {
        return true;
    }
    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
        damageMult = 1.18f;
        critBonus = 7;
        useTimeMult = 0.8f;
    }
}
