using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class ZincHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zinc Hammer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ZincHammer");
            item.damage = 9;
            item.autoReuse = true;
            item.hammer = 49;
            item.useTurn = true;
            item.scale = 1.2f;
            item.width = dims.Width;
            item.useTime = 18;
            item.knockBack = 4.5f;
            item.melee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 1500;
            item.useAnimation = 28;
            item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
    }}