using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

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
				mod.AddPrefix("Confused", new Confused());
			}
			return false;
		}
        public override void InsertTooltips(Item item, List<TooltipLine> tooltips, int index)
        {
            tooltips.Insert(index, PrefixLine(true, "[c/BE7878:You are confused]"));
        }
        public override void UpdateEquip(Player player)
        {
            player.confused = true;
        }
	}
}
