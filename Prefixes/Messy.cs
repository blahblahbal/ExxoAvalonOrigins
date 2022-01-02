using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes
{
	public class Messy : ArmorPrefix
	{
		public Messy()
		{

		}

		public override bool CanRoll(Item item)
		{
            return IsArmor(item);
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 0.9f;
		}

		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Messy", new Messy());
			}
			return false;
		}
        public override void UpdateEquip(Player player)
		{
			player.allDamage -= 0.05f;
		}
	}
}
