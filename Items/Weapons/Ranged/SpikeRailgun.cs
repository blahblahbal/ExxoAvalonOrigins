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
            Item.damage = 120;
            Item.autoReuse = true;
            Item.useTurn = false;
            Item.useAmmo = ItemID.Spike;
            Item.shootSpeed = 23f;
            Item.crit += 2;
            Item.DamageType = DamageClass.Ranged;
            Item.rare = ItemRarityID.Cyan;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.knockBack = 8f;
            Item.useTime = 9;
            Item.shoot = ModContent.ProjectileType<Projectiles.SpikeCannon>();
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 9;
            Item.height = dims.Height;
            Item.UseSound = Mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Railgun");
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<SpikeCannon>()).AddIngredient(ModContent.ItemType<Placeable.Tile.Phantoplasm>(), 25).AddIngredient(ModContent.ItemType<Material.SoulofBlight>(), 15).AddTile(TileID.TinkerersWorkbench).Register();
        }
    }
}
