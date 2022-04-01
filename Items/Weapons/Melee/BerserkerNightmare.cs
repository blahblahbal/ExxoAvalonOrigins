using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class BerserkerNightmare : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Nightmare");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.noUseGraphic = true;
            Item.damage = 84;
            Item.autoReuse = true;
            Item.channel = true;
            Item.scale = 1.1f;
            Item.shootSpeed = 10f;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.useTime = 38;
            Item.knockBack = 10f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.BerserkerSphere>();
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(0, 50, 0, 0);
            Item.useAnimation = 38;
            Item.height = dims.Height;
        }

        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.BerserkerBar>(), 60).AddIngredient(ModContent.ItemType<Material.SoulofTorture>(), 75).AddIngredient(ModContent.ItemType<Material.ElementShard>(), 7).AddIngredient(ModContent.ItemType<Material.VictoryPiece>()).AddIngredient(ItemID.Flairon).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
    }
}
