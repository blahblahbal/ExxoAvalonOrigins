using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class HellsteelEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hellsteel Emblem");
            Tooltip.SetDefault("12% increased critical strike damage\n15% increased damage\nProvides immunity to traps");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Red;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 9);
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.allDamage += 0.15f;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().critDamageMult += 0.12f;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().trapImmune = true;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<ChaosEmblem>());
            r.AddIngredient(ModContent.ItemType<GuardianBoots>());
            r.AddIngredient(ModContent.ItemType<Material.HellsteelPlate>(), 20);
            r.AddTile(ModContent.TileType<Tiles.SolariumAnvil>());
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}
