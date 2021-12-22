using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
	class ElementalExcalibur : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Excalibur");
		}
		public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 190;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
			item.scale = 1.2f;
			item.shootSpeed = 13f;
			item.rare = ItemRarityID.Cyan;
			item.noMelee = false;
			item.width = dims.Width;
			item.useTime = 15;
			item.knockBack = 8.5f;
			item.shoot = ModContent.ProjectileType<Projectiles.ElementBeam>();
			item.melee = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = Item.sellPrice(0, 90, 0, 0);
			item.useAnimation = 10;
			item.height = dims.Height;
		}
		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 255);
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			int randomNum = Main.rand.Next(8);
			if (randomNum == 0) target.AddBuff(20, 300);
			else if (randomNum == 1) target.AddBuff(24, 200);
			else if (randomNum == 2) target.AddBuff(31, 120);
			else if (randomNum == 3) target.AddBuff(39, 300);
			else if (randomNum == 4) target.AddBuff(44, 300);
			else if (randomNum == 5) target.AddBuff(70, 240);
			else if (randomNum == 6) target.AddBuff(69, 300);
			else if (randomNum == 7)
			{
				if (CanBeFrozen.CanFreeze(target))
					target.AddBuff(ModContent.BuffType<Buffs.Frozen>(), 60);
				else
					randomNum = Main.rand.Next(7);
			}
		}
		public override void OnHitPvp(Player player, Player target, int damage, bool crit)
		{
			int randomNum = Main.rand.Next(8);
			if (randomNum == 0) target.AddBuff(20, 300);
			else if (randomNum == 1) target.AddBuff(24, 200);
			else if (randomNum == 2) target.AddBuff(31, 120);
			else if (randomNum == 3) target.AddBuff(39, 300);
			else if (randomNum == 4) target.AddBuff(44, 300);
			else if (randomNum == 5) target.AddBuff(70, 240);
			else if (randomNum == 6) target.AddBuff(69, 300);
			else if (randomNum == 7) target.AddBuff(BuffID.Frozen, 60);
		}
	}
}
