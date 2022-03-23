using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class TroxiniumSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Troxinium Spear");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item1;
            item.damage = 41;
            item.noUseGraphic = true;
            item.scale = 1.1f;
            item.shootSpeed = 5f;
            item.rare = ItemRarityID.Pink;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 23;
            item.knockBack = 5.6f;
            item.shoot = ModContent.ProjectileType<Projectiles.Melee.TroxiniumSpear>();
            item.melee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 100000;
            item.useAnimation = 23;
            item.height = dims.Height;
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = mod.GetTexture("Items/Weapons/Melee/TroxiniumSpear_Glow");
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
