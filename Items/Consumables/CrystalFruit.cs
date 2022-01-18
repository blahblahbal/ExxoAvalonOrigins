using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables
{
    class CrystalFruit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal Fruit");
            Tooltip.SetDefault("Permanently increases maximum life by 25\nCan only be used when you have 500 or more life");
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
            return player.statLifeMax >= 500 && player.GetModPlayer<ExxoAvalonOriginsModPlayer>().crystalHealth < 4;
        }

        public override bool UseItem(Player player)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().crystalHealth += 1;
            player.statLifeMax += 25;
            player.statLife += 25;
            player.statLifeMax2 += 25;
            return true;
        }
    }
}
