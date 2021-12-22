using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class StaminaCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stamina Crystal");
            Tooltip.SetDefault("Permanently increases maximum stamina by 20");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.consumable = true;
            item.rare = ItemRarityID.Orange;
            item.width = dims.Width;
            item.useTime = 30;
            item.maxStack = 999;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.UseSound = SoundID.Item29;
            item.value = 95000;
            item.useAnimation = 30;
            item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax < 300;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax += 30;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStamMax2 += 30;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().statStam += 30;
            return true;
        }
    }
}