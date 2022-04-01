using ExxoAvalonOrigins.Items.Placeable.Bar;
using ExxoAvalonOrigins.Logic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    public class BerserkerBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Blade");
            Tooltip.SetDefault("'Go berserk!'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 166;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.useTurn = true;
            Item.scale = 1.2f;
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.useTime = 10;
            Item.knockBack = 5f;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = Item.sellPrice(0, 12);
            Item.useAnimation = 10;
            Item.height = dims.Height;
            if (!Main.dedServ)
            {
                Item.GetGlobalItem<ItemUseGlow>().glowTexture = ModContent.Request<Texture2D>(Texture + "_Glow");
            }
        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = Mod.Assets.Request<Texture2D>("Items/Weapons/Melee/BerserkerBlade_Glow").Value;
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                    Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
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
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<BerserkerBar>(), 40).AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 20).AddIngredient(ModContent.ItemType<Material.ElementShard>(), 5).AddIngredient(ModContent.ItemType<Material.VictoryPiece>()).AddIngredient(ModContent.ItemType<VoraylzumKatana>()).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
            CreateRecipe(1).AddIngredient(ModContent.ItemType<BerserkerBar>(), 40).AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 20).AddIngredient(ModContent.ItemType<Material.ElementShard>(), 5).AddIngredient(ModContent.ItemType<Material.VictoryPiece>()).AddIngredient(ModContent.ItemType<UnvolanditeGreatsword>()).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
    }
}
