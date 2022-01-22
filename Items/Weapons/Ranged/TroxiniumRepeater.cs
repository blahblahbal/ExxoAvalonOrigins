using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    public class TroxiniumRepeater : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Troxinium Repeater");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item5;
            item.damage = 42;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10.5f;
            item.ranged = true;
            item.noMelee = true;
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.useTime = 21;
            item.knockBack = 1.5f;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = 100000;
            item.useAnimation = 21;
            item.height = dims.Height;
            if (!Main.dedServ)
            {
                item.GetGlobalItem<ItemUseGlow>().glowTexture = ModContent.GetTexture(Texture + "_Glow");
            }
            item.GetGlobalItem<ItemUseGlow>().glowOffsetX = -5;
            item.GetGlobalItem<ItemUseGlow>().glowOffsetY = 0;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.GetTexture(Texture + "_Glow");
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
