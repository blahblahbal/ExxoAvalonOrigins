using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes
{
    public class Marvelous : ModPrefix
    {
        public Marvelous()
        {

        }

        public override PrefixCategory Category { get { return PrefixCategory.AnyWeapon; } }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.25f;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix("Marvelous", new Marvelous());
            }
            return false;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult = 1.14f;
            useTimeMult = 1.03f;
        }
    }
}