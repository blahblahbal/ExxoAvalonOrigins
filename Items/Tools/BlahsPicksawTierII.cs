using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Tools
{
    class BlahsPicksawTierII : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blah's Picksaw (Tier II)");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.damage = 55;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.15f;
            Item.axe = 60;
            Item.pick = 700;
            Item.rare = 11;
            Item.width = dims.Width;
            Item.useTime = 6;
            Item.knockBack = 5.5f;
            Item.DamageType = DamageClass.Melee;
            Item.tileBoost += 8;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 5016000;
            Item.useAnimation = 6;
            Item.height = dims.Height;
        }
        public override void HoldItem(Player player)
        {
            if (player.inventory[player.selectedItem].type == Item.type)
            {
                player.pickSpeed -= 0.75f;
            }
        }
    }
}
