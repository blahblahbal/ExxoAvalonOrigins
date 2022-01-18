using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Magic
{
    class MagmafrostBolt : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magmafrost Bolt");
            Tooltip.SetDefault("Casts a superfast-moving bolt of igneonic frost");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.magic = true;
            item.damage = 67;
            item.autoReuse = true;
            item.useTurn = true;
            item.shootSpeed = 10f;
            item.mana = 10;
            item.rare = ItemRarityID.Yellow;
            item.noMelee = true;
            item.width = dims.Width;
            item.useTime = 15;
            item.knockBack = 5f;
            item.shoot = ModContent.ProjectileType<Projectiles.MagmafrostBolt>();
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.useAnimation = 15;
            item.height = dims.Height;
            item.UseSound = SoundID.Item21;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<FreezeBolt>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.DragonScale>(), 10);
            recipe.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 50);
            recipe.AddIngredient(ItemID.LivingFireBlock, 40);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
