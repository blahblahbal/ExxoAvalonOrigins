using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class TerraClaws : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Claws");
            Tooltip.SetDefault("Increases melee damage and speed by 10%\nMelee attacks will burn, poison, envenom, frostburn, or ichor your enemies");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = 11;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 15, 0, 0);
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Avalon().terraClaws = true;
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.meleeSpeed += 0.1f;
        }
    }
}
