using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class DragonsBondage : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon's Bondage");
            Tooltip.SetDefault("'Your victory weighs on you... literally.'");
        }

        public override void SetDefaults()
        {
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/Accessories/DragonsBondage");
            item.rare = -12;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 15, 0, 0);
            //item.buffType = ModContent.BuffType<Buffs.DragonsChains>();
            item.height = dims.Height;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ExxoAvalonOriginsModPlayer>().dragonsBondage = true;
            //player.AddBuff(item.buffType, 2, true);
        }
    }
}
