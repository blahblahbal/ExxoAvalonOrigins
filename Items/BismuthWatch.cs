using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class BismuthWatch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Watch");
            Tooltip.SetDefault("Tells the time");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.GoldWatch);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.accWatch < 1) player.accWatch = 1;
        }

        public override void UpdateInventory(Player player)
        {
            if (player.accWatch < 1) player.accWatch = 1;
        }
    }}