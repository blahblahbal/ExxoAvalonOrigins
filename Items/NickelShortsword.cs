using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class NickelShortsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Shortsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/NickelShortsword");
            item.damage = 9;
            item.useTurn = true;
            item.scale = 1f;
            item.width = dims.Width;
            item.useTime = 11;
            item.knockBack = 4f;
            item.melee = true;
            item.useStyle = 3;
            item.value = 1000;
            item.useAnimation = 11;
            item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
    }}