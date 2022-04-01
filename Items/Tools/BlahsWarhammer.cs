using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class BlahsWarhammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah's Warhammer");
            Tooltip.SetDefault("You shouldn't have this");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 80;
            Item.autoReuse = true;
            Item.hammer = 250;
            Item.useTurn = true;
            Item.scale = 1.15f;
            Item.rare = ItemRarityID.Red;
            Item.width = dims.Width;
            Item.useTime = 9;
            Item.knockBack = 20f;
            Item.DamageType = DamageClass.Melee;
            Item.tileBoost += 6;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 1016000;
            Item.useAnimation = 9;
            Item.height = dims.Height;
        }
        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == Item.type)
            {
                player.wallSpeed += 0.5f;
            }
        }
    }
}
