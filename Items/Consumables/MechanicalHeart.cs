using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables;

class MechanicalHeart : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Mechanical Heart");
        Tooltip.SetDefault("Permanently increases accessory slots by 1");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.UseSound = SoundID.Item4;
        Item.consumable = true;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.useTime = 30;
        Item.maxStack = 999;
        Item.useStyle = ItemUseStyleID.HoldUp;
        Item.value = Item.sellPrice(0, 3, 0, 0);
        Item.useAnimation = 30;
        Item.height = dims.Height;
    }

    public override bool CanUseItem(Player player)
    {
        return !player.Avalon().shmAcc;
    }

    public override bool? UseItem(Player player)
    {
        player.extraAccessorySlots++;
        player.Avalon().shmAcc = true;
        return true;
    }
}
