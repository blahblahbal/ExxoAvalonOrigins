using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class BronzeShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Shortsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BronzeShortsword");
            item.damage = 7;
            item.useTurn = true;
            item.scale = 1f;
            item.width = dims.Width;
            item.useTime = 13;
            item.knockBack = 5.2f;
            item.melee = true;
            item.useStyle = 3;
            item.value = 900;
            item.useAnimation = 13;
            item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
    }}