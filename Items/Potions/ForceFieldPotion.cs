using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class ForceFieldPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force Field Potion");
            Tooltip.SetDefault("Enables a projectile-reflecting force field");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.buffType = ModContent.BuffType<Buffs.ForceField>();
            Item.consumable = true;
            Item.rare = ItemRarityID.LightRed;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.maxStack = 100;
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.buffTime = 18000;
            Item.UseSound = SoundID.Item3;
        }
    }
}
