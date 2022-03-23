using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Ranged
{
    class SpikeRailgun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spike Railgun");
            Tooltip.SetDefault("Uses spikes for ammo\nShoots spikes at extreme velocity");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 120;
            item.autoReuse = true;
            item.useTurn = false;
            item.useAmmo = ItemID.Spike;
            item.shootSpeed = 23f;
            item.crit += 2;
            item.ranged = true;
            item.rare = ItemRarityID.Cyan;
            item.noMelee = true;
            item.width = dims.Width;
            item.knockBack = 8f;
            item.useTime = 9;
            item.shoot = ModContent.ProjectileType<Projectiles.SpikeCannon>();
            item.value = Item.sellPrice(0, 20, 0, 0);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 9;
            item.height = dims.Height;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Railgun");
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<SpikeCannon>());
            recipe.AddIngredient(ModContent.ItemType<Placeable.Tile.Phantoplasm>(), 25);
            recipe.AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 15);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
