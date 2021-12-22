using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    internal class AlchemicalSkull : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Alchemical Skull");
            Tooltip.SetDefault("Increases spawn rate and Attackers also take damage"
                + "\nThe wearer can walk on water and lava"
                + "\nGrants immunity to knockback and fire blocks");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 8;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.accessory = true;
            item.value = 150000;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.waterWalk = (player.waterWalk2 = (player.enemySpawns = /*(player.thorns = */(player.noKnockback = (player.fireWalk = true))/*)*/));
        }
    }
}
