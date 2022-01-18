using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
	class PyroscoricPickaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pyroscoric Pickaxe");
		}
        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(255, 255, 255, 200);
        }
        public override void SetDefaults()
		{
			Rectangle dims = this.GetDims();
			item.damage = 30;
			item.autoReuse = true;
			item.useTurn = true;
			item.scale = 1.15f;
			item.pick = 250;
			item.rare = ItemRarityID.Yellow;
			item.width = dims.Width;
			item.useTime = 9;
			item.knockBack = 3.5f;
			item.melee = true;
			item.tileBoost += 2;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.value = 416000;
			item.useAnimation = 9;
			item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(2) == 0)
            {
                int num162 = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Fire, 0f, 0f, 0, default(Color), 2f);
                Main.dust[num162].noGravity = true;
            }
        }
    }
}
