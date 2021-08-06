using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class NickelHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nickel Hammer");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/NickelHammer");
            item.damage = 8;
            item.autoReuse = true;
            item.hammer = 45;
            item.useTurn = true;
            item.scale = 1.22f;
            item.width = dims.Width;
            item.useTime = 17;
            item.knockBack = 4.5f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 800;
            item.useAnimation = 27;
            item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
    }}