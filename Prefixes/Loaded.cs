using Terraria;using Terraria.ModLoader;namespace ExxoAvalonOrigins.Prefixes{	public class Loaded : ModPrefix	{		public Loaded()		{		}		public override bool CanRoll(Item item)		{			return false;		}		public override void ModifyValue(ref float valueMult)		{			valueMult *= 1.15f;		}		public override bool Autoload(ref string name)		{			if (base.Autoload(ref name))			{				mod.AddPrefix("Loaded", new Loaded());			}			return false;		}		public override void Apply(Item item)		{			Main.player[Main.myPlayer].statDefense++;		}		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)		{		}	}}