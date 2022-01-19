using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class TritanoriumPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tritanorium Pickaxe");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.damage = 30;
            item.autoReuse = true;
            item.useTurn = true;
            item.scale = 1.15f;
            item.pick = 260;
            item.rare = ItemRarityID.Yellow;
            item.width = dims.Width;
            item.useTime = 13;
            item.knockBack = 6.5f;
            item.melee = true;
            item.tileBoost += 2;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = 516000;
            item.useAnimation = 15;
            item.height = dims.Height;
            item.UseSound = SoundID.Item1;
        }
        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == item.type)
            {
                player.pickSpeed -= 0.25f;
            }
        }
    }
}
