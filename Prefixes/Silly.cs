using Terraria;

namespace ExxoAvalonOrigins.Prefixes
{
    public class Silly : ArmorPrefix
    {
        public Silly()
        {

        }

        public override bool CanRoll(Item item)
        {
            return IsArmor(item);
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.2f;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix("Silly", new Silly());
            }
            return false;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 2;
            player.meleeCrit += 2;
            player.rangedCrit += 2;
            player.thrownCrit += 2;
        }
    }
}
