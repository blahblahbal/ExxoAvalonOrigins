using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Prefixes
{
	public class Barbaric : ModPrefix
	{
		public Barbaric()
		{

		}

		public override bool CanRoll(Item item)
		{
			return false;
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

		public override void Apply(Item item)
		{
			Main.player[Main.myPlayer].magicDamage += 0.04f;
			Main.player[Main.myPlayer].meleeDamage += 0.04f;
			Main.player[Main.myPlayer].minionDamage += 0.04f;
			Main.player[Main.myPlayer].rangedDamage += 0.04f;
			item.knockBack += 0.06f;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
		}
	}
}