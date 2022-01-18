using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes
{
    public class Awestruck : ModPrefix
    {
        public Awestruck()
        {

        }

        public override PrefixCategory Category { get { return PrefixCategory.Melee; } }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix("Awestruck", new Awestruck());
            }
            return false;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            knockbackMult = 1.2f;
            damageMult = 1.19f;
            critBonus = 6;
            useTimeMult = 0.85f;
            scaleMult = 1.13f;
        }
    }
}