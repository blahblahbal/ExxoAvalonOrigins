using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class ForsakenRelic : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forsaken Relic");
            Tooltip.SetDefault("Increases damage and critical strike chance by 7% while invincible");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Pink;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.immune)
            {
                player.GetCritChance(DamageClass.Magic) += 7;
                player.GetCritChance(DamageClass.Melee) += 7;
                player.GetCritChance(DamageClass.Ranged) += 7;
                player.GetDamage(DamageClass.Magic) += 0.07f;
                player.GetDamage(DamageClass.Melee) += 0.07f;
                player.GetDamage(DamageClass.Ranged) += 0.07f;
                player.GetDamage(DamageClass.Summon) += 0.07f;
            }
        }
    }
}
