using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class ZincBroadsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Broadsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ZincBroadsword");
            item.damage = 13;
            item.useTurn = true;
            item.scale = 1.12f;
            item.width = dims.Width;
            item.useTime = 23;
            item.knockBack = 5.2f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 1500;
            item.useAnimation = 23;
            item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
    }}