using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables;

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
        return player.statLifeMax >= 500 && player.Avalon().crystalHealth < 4;
    }

    public override bool? UseItem(Player player)
    {
        player.Avalon().crystalHealth += 1;
        player.statLifeMax += 25;
        player.statLife += 25;
        player.statLifeMax2 += 25;
        return true;
    }
}