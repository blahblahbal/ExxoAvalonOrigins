using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables;

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
        Item.UseSound = SoundID.Item4;
        Item.consumable = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.maxStack = 999;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.value = Item.sellPrice(0, 0, 50, 0);
        Item.useAnimation = 30;
        Item.height = dims.Height;
    }

    public override bool CanUseItem(Player player)
    {
        return player.statManaMax >= 200 && player.Avalon().spiritPoppyUseCount < 10;
    }

    public override bool? UseItem(Player player)
    {
        player.Avalon().spiritPoppyUseCount++;
        return true;
    }
}