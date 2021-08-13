using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class SoulEdge : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Soul Edge");			Tooltip.SetDefault("'Haunted by souls of darkness'");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/SoulEdge");
			item.UseSound = SoundID.Item1;			item.damage = 83;			item.autoReuse = true;			item.scale = 1.1f;			item.shootSpeed = 8f;			item.rare = 8;			item.noMelee = false;			item.width = dims.Width;			item.useTime = 20;			item.knockBack = 6.5f;			item.shoot = 297;			item.melee = true;			item.useStyle = 1;			item.value = Item.sellPrice(0, 80, 0, 0);			item.useAnimation = 15;			item.height = dims.Height;		}
		public override Color? GetAlpha(Color lightColor)		{			return new Color(255, 255, 255, 150);		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(2); // 4 or 5 shots
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(25));
				//float scale = 1f - (Main.rand.NextFloat() * .3f);
				//perturbedSpeed = perturbedSpeed * scale; 
				int spirit = Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				Main.projectile[spirit].magic = false;
				Main.projectile[spirit].melee = true;
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}
        public override bool OnlyShootOnSwing => base.OnlyShootOnSwing;
    }}