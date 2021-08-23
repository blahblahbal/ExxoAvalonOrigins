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
    class DarkStarHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Star Heart");
            Tooltip.SetDefault("Permanently increases accessory slots by 1");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/DarkStarHeart");
            item.UseSound = SoundID.Item4;
            item.consumable = true;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.useTime = 30;
            item.maxStack = 999;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.useAnimation = 30;
            item.height = dims.Height;
        }

        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shmAcc;
        }

        public override bool UseItem(Player player)
        {
            player.extraAccessorySlots++;
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().shmAcc = true;
            return true;
        }
    }
}