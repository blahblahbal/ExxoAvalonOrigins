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
    class BronzeAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Axe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BronzeAxe");
            item.UseSound = SoundID.Item1;
            item.damage = 3;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.05f;
            item.axe = 8;
            item.width = dims.Width;
            item.useTime = 20;
            item.knockBack = 4f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 700;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 28;
            item.height = dims.Height;
        }
    }
}