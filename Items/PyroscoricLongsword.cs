using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class PyroscoricLongsword : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Pyroscoric Flamesword");			Tooltip.SetDefault("Shoots a wave of fire\n'It burns, I tell you!'");		}
        public override Color? GetAlpha(Color lightColor)
        {
			return new Color(255, 255, 255, 200);
        }
        public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/PyroscoricLongsword");			item.damage = 131;			item.autoReuse = true;			item.useTurn = true;			item.scale = 1.3f;			item.rare = 8;			item.width = dims.Width;			item.useTime = 25;
			item.useAnimation = 25;			item.knockBack = 7f;			item.melee = true;			item.useStyle = 1;			item.shoot = ModContent.ProjectileType<Projectiles.FireWave>();			item.shootSpeed = 25f;			item.value = Item.sellPrice(0, 7, 63, 0);			item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int num162 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6, 0f, 0f, 0, default(Color), 2f);
				Main.dust[num162].noGravity = true;
			}
		}
    }}