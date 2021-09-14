using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes
{
	public class Slimy : ModPrefix
	{
		public Slimy()
		{

		}

		public override bool CanRoll(Item item)
		{
			return false;
		}

		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Slimy", new Slimy());
			}
			return false;
		}

		public override void Apply(Item item)
		{
			Main.player[Main.myPlayer].endurance += 0.05f;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
		}
	}
}