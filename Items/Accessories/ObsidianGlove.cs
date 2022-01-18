using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class ObsidianGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Obsidian Glove");
            Tooltip.SetDefault("The wearer can place blocks and walls in midair and in lava\nProvides immunity to fire blocks");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.height = dims.Height;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().updateInvisibleVanity = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().cloudGloves = true;
        }
        public override void UpdateVanity(Player player, EquipType type)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().cloudGloves = true;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<CloudGloves>());
            r.AddIngredient(ItemID.ObsidianSkull);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
