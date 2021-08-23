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
    class ZincAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Axe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ZincAxe");
            item.UseSound = SoundID.Item1;
            item.damage = 4;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.05f;
            item.axe = 11;
            item.width = dims.Width;
            item.useTime = 17;
            item.knockBack = 4f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 1500;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 25;
            item.height = dims.Height;
        }
    }
}