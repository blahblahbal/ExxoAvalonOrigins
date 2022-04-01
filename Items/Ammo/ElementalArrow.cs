using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Ammo
{
    class ElementalArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Elemental Arrow");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 17;
            Item.shootSpeed = 3.5f;
            Item.ammo = AmmoID.Arrow;
            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;
            Item.rare = ItemRarityID.Yellow;
            Item.width = dims.Width;
            Item.knockBack = 5f;
            Item.shoot = ModContent.ProjectileType<Projectiles.ElementalArrow>();
            Item.value = Item.sellPrice(0, 0, 3, 0);
            Item.maxStack = 2000;
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(250).AddIngredient(ItemID.WoodenArrow, 250).AddIngredient(ModContent.ItemType<Material.ElementShard>(), 2).AddTile(ModContent.TileType<Tiles.CaesiumForge>()).Register();
        }
    }
}
