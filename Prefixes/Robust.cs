using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes
{
    public class Robust : ModPrefix
    {
        public Robust()
        {

        }

        public override PrefixCategory Category { get { return PrefixCategory.Accessory; } }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.25f;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix("Robust", new Robust());
            }
            return false;
        }

        public override void Apply(Item item)
        {
            Main.player[Main.myPlayer].statDefense += 3;
            Main.player[Main.myPlayer].meleeDamage += 0.03f;
            Main.player[Main.myPlayer].rangedDamage += 0.03f;
            Main.player[Main.myPlayer].magicDamage += 0.03f;
            Main.player[Main.myPlayer].minionDamage += 0.03f;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
        }
    }
}