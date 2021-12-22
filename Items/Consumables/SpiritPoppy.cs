using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class SpiritPoppy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Poppy");
            Tooltip.SetDefault("Permanently increases maximum mana by 20\nCan only be used when you have 200 or more mana\nMaxes at 400 mana");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.UseSound = SoundID.Item4;
            item.consumable = true;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.useTime = 30;
            item.maxStack = 999;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.value = Item.sellPrice(0, 0, 50, 0);
            item.useAnimation = 30;
            item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            return player.statManaMax >= 200 && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().spiritPoppyUseCount < 10;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().spiritPoppyUseCount++;
            return true;
        }
    }
}
