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
            Item.rare = -12;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 15, 0, 0);
            Item.buffType = ModContent.BuffType<Buffs.StingerProbe>();
            Item.height = dims.Height;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(Item.buffType, 2, true);
        }
    }
}
