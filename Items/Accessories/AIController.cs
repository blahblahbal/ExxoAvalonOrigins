using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    public class AIController : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AI Controller");
            Tooltip.SetDefault("Stinger probe minions circle you"
                + "\nThis probe will reflect hostile projectiles and explodes"
                + "\nProbes will regenerate over time, to a max of four");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = -12;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.buffType = ModContent.BuffType<Buffs.StingerProbe>();
            item.height = dims.Height;
            item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(item.buffType, 2, true);
        }
    }
}
