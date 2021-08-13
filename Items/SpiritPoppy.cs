using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
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
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/SpiritPoppy");
            item.UseSound = SoundID.Item4;
            item.consumable = true;
            item.rare = 8;
            item.width = dims.Width;
            item.useTime = 30;
            item.maxStack = 999;
            item.useStyle = 4;
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