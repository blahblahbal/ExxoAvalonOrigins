using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class GuardianBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Boots");
            Tooltip.SetDefault("Provides immunity to traps and knockback");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 2;
            item.rare = ItemRarityID.Pink;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 1, 44, 0);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianHorseshoe);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ItemID.Spike, 50);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ObsidianShield);
            recipe.AddIngredient(ItemID.LuckyHorseshoe);
            recipe.AddIngredient(ItemID.Spike, 50);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().trapImmune = true;
            player.noKnockback = true;
            player.noFallDmg = true;
            player.fireWalk = true;
        }
    }
}
