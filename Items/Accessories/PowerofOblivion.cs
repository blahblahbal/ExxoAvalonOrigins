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
            Tooltip.SetDefault("Automatically use mana and stamina potions when needed\nIncreases maximum stamina by 60\nReduces the cooldown of healing potions\nProvides life, mana, and stamina regeneration");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Lime;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 9);
            Item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            CreateRecipe(1).AddIngredient(ModContent.ItemType<RestorationBand>()).AddIngredient(ModContent.ItemType<StaminaFlower>()).AddIngredient(ItemID.CharmofMyths).AddIngredient(ItemID.ManaFlower).AddTile(TileID.TinkerersWorkbench).Register();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().statStamMax2 += 60;
            player.manaFlower = true;
            player.Avalon().stamFlower = true;
            player.pStone = true;
            player.lifeRegen += 2;
            player.manaRegen++;
            player.Avalon().staminaRegen = 1600;
        }
    }
}
