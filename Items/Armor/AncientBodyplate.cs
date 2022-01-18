using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class AncientBodyplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Bodyplate");
            Tooltip.SetDefault("Enemies are more likely to target you\nMinion knockback is increased by 10%");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 35;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 40, 0, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.SolarFlareBreastplate);
            r.AddIngredient(ItemID.FragmentNebula, 10);
            r.AddIngredient(ItemID.FragmentStardust, 10);
            r.AddIngredient(ItemID.FragmentVortex, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.NebulaBreastplate);
            r.AddIngredient(ItemID.FragmentSolar, 10);
            r.AddIngredient(ItemID.FragmentStardust, 10);
            r.AddIngredient(ItemID.FragmentVortex, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.StardustBreastplate);
            r.AddIngredient(ItemID.FragmentNebula, 10);
            r.AddIngredient(ItemID.FragmentSolar, 10);
            r.AddIngredient(ItemID.FragmentVortex, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();

            r = new ModRecipe(mod);
            r.AddIngredient(ItemID.VortexBreastplate);
            r.AddIngredient(ItemID.FragmentNebula, 10);
            r.AddIngredient(ItemID.FragmentStardust, 10);
            r.AddIngredient(ItemID.FragmentSolar, 10);
            r.AddIngredient(ModContent.ItemType<Material.LifeDew>(), 5);
            r.AddIngredient(ModContent.ItemType<Material.GhostintheMachine>());
            r.AddTile(ModContent.TileType<Tiles.CaesiumForge>());
            r.SetResult(this);
            r.AddRecipe();
        }
        public override void UpdateEquip(Player player)
        {
            player.aggro += 500;
            player.minionKB += 0.1f;
        }
    }
}
