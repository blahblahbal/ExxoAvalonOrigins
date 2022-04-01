using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class UnvolanditePicksaw : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unvolandite Picksaw");
            Tooltip.SetDefault("Can mine Oblivion Ore");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 30;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.15f;
            Item.axe = 22;
            Item.pick = 300;
            Item.rare = ItemRarityID.Cyan;
            Item.width = dims.Width;
            Item.useTime = 9;
            Item.knockBack = 5.5f;
            Item.DamageType = DamageClass.Melee;
            Item.tileBoost += 5;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 416000;
            Item.useAnimation = 11;
            Item.height = dims.Height;
        }
        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == Item.type)
            {
                player.pickSpeed -= 0.35f;
            }
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<Placeable.Bar.UnvolanditeBar>(), 20).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 5).AddTile(ModContent.TileType<Tiles.SolariumAnvil>()).Register();
        }
    }
}
