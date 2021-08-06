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
    class NickelAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Axe");
        }
        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/NickelAxe");
            item.UseSound = SoundID.Item1;
            item.damage = 4;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.05f;
            item.axe = 10;
            item.width = dims.Width;
            item.useTime = 18;
            item.knockBack = 4f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 800;
            item.UseSound = SoundID.Item1;
            item.useAnimation = 26;
            item.height = dims.Height;
        }
    }
}