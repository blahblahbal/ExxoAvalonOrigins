using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes
{
	public class Mythic : ModPrefix
	{
		public Mythic()
		{

		}

		public override bool CanRoll(Item item)
		{
			return false;
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1.1f;
		}

		public override bool Autoload(ref string name)
		{
			if (base.Autoload(ref name))
			{
				mod.AddPrefix("Mythic", new Mythic());
			}
			return false;
		}

		public override void Apply(Item item)
		{
			Main.player[Main.myPlayer].statManaMax2 += 20;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
		}
	}
}