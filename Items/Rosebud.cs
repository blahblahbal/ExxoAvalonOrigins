using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace ExxoAvalonOrigins.Items
{
	class Rosebud : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rosebud");
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/Rosebud");
			item.width = dims.Width;
			item.height = dims.Height;
		}

        public override bool CanPickup(Player player) { return true; }

        public override bool OnPickup(Player player)
        {
            int rand = Main.rand.Next(10, 16);
            if (player.statLife + rand > player.statLifeMax2) player.statLife = player.statLifeMax2; else player.statLife += rand;
            if (Main.myPlayer == player.whoAmI)
            {
                player.HealEffect(rand, true);
            }
            Main.PlaySound(SoundID.Grab, player.position);
            return false;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.GetTexture("ExxoAvalonOrigins/Items/RosebudGlow");
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
    }
}