using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class BronzeHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Hammer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BronzeHammer");
            item.damage = 7;
            item.autoReuse = true;
            item.hammer = 39;
            item.useTurn = true;
            item.scale = 1.2f;
            item.width = dims.Width;
            item.useTime = 21;
            item.knockBack = 4.5f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 700;
            item.useAnimation = 31;
            item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
    }}