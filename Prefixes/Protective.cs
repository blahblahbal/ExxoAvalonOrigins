using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes
{
	public class Protective : ArmorPrefix
	{
		public Protective()
		{

		}

		public override bool CanRoll(Item item)
		{
            return IsArmor(item);
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.15f;
		}

		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Protective", new Protective());
			}
			return false;
		}
        public override void UpdateEquip(Player player)
		{
			player.statDefense += 2;
		}
	}
}
