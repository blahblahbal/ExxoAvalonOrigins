using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class IridiumGreatsword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Greatsword");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/IridiumGreatsword");
            item.damage = 30;
            item.crit = 6;
            item.rare = 4;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.4f;
            item.width = dims.Width;
            item.useTime = 18;
            item.knockBack = 5.4f;
            item.melee = true;
            item.useStyle = 1;
            item.value = 50000;
            item.useAnimation = 18;
            item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
    }}