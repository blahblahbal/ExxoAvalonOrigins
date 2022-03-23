using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class DarkStarHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mechanical Heart");
            Tooltip.SetDefault("Permanently increases accessory slots by 1");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
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
            return !player.Avalon().shmAcc;
        }

        public override bool UseItem(Player player)
        {
            player.extraAccessorySlots++;
            player.Avalon().shmAcc = true;
            return true;
        }
    }
}
