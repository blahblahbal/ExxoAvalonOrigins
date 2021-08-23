using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{
    class VampireTeeth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Teeth");
            Tooltip.SetDefault("Grants the ability for true melee attacks to lifesteal");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/VampireTeeth");
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.height = dims.Height;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().vampireTeeth = true;
        }
    }}