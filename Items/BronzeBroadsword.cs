using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class BronzeBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Broadsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/BronzeBroadsword");
            item.damage = 7;
            item.useTurn = true;
            item.scale = 1.1f;
            item.width = dims.Width;
            item.useTime = 23;
            item.knockBack = 5.2f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 900;
            item.useAnimation = 23;
            item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
    }}