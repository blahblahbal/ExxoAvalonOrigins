using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class PowerofOblivion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Power of Oblivion");
            Tooltip.SetDefault("Automatically use mana and stamina potions when needed\nIncreases maximum stamina by 40\nReduces the cooldown of healing potions\nProvides life, mana, and stamina regeneration");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.Lime;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 9);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ModContent.ItemType<RestorationBand>());
            r.AddIngredient(ModContent.ItemType<StaminaFlower>());
            r.AddIngredient(ItemID.CharmofMyths);
            r.AddIngredient(ItemID.ManaFlower);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().statStamMax2 += 40;
            player.manaFlower = true;
            player.Avalon().stamFlower = true;
            player.pStone = true;
            player.lifeRegen += 2;
            player.manaRegen++;
            player.Avalon().staminaRegen = 1600;
        }
    }
}
