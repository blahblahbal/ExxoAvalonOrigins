using Terraria;

namespace ExxoAvalonOrigins.Prefixes
{
    public class Barbaric : ArmorPrefix
    {
        public Barbaric()
        {

        }

        public override bool CanRoll(Item item)
        {
            return IsArmor(item);
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.25f;
        }

        public override bool Autoload(ref string name)
        {
            if (base.Autoload(ref name))
            {
                mod.AddPrefix("Barbaric", new Barbaric());
            }
            return false;
        }
        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.04f;
            player.Avalon().bonusKB = 1.06f;
            //player.inventory[player.selectedItem].knockBack += 0.06f;
        }
    }
}
