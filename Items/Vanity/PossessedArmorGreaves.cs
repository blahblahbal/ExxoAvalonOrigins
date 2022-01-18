﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Vanity
{
    [AutoloadEquip(EquipType.Legs)]
    class PossessedArmorGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Possessed Armor Greaves");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.vanity = true;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.height = dims.Height;
        }
    }
}
