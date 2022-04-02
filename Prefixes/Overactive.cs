using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes;

public class Overactive : ModPrefix
{
    public Overactive()
    {

    }

    public override bool CanRoll(Item item)
    {
        return false;
    }

    public override void ModifyValue(ref float valueMult)
    {
        valueMult *= 1.1f;
    }

    // public override bool Autoload(ref string name)
    // {
    //     if (base.Autoload(ref name))
    //     {
    //         Mod.AddPrefix("Overactive", new Overactive());
    //     }
    //     return false;
    // }

    public override void Apply(Item item)
    {
        Main.player[Main.myPlayer].statManaMax2 += 20;
        Main.player[Main.myPlayer].manaCost += 0.04f;
    }

    public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
    {
    }
}
