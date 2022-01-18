using Terraria;

namespace ExxoAvalonOrigins.Prefixes
{
    public class Confused : ArmorPrefix
    {
        public Confused()
        {

        }

        public override bool CanRoll(Item item)
        {
            return IsArmor(item);
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix("Bloated", new Confused());
            }
            return false;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.05f;
            player.meleeSpeed -= 0.02f;
        }
    }
}
