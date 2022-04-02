using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Items.Other;

class Quack : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Quack");
        Tooltip.SetDefault("'May annoy others'");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.noUseGraphic = true;
        Item.rare = ItemRarityID.Red;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
        Item.width = dims.Width;
        Item.useTurn = true;
        Item.useTime = 30;
        Item.useStyle = 10;
        Item.value = 100;
        Item.useAnimation = 30;
        Item.height = dims.Height;
    }

    public override bool? UseItem(Player player)
    {
        Main.PlaySound(SoundID.Zombie, -1, -1, 12);
        return true;
    }
    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        foreach (TooltipLine line in tooltips)
        {
            if (line.mod == "Terraria" && line.Name == "ItemName")
            {
                line.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
            }
        }
    }
}