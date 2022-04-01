using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Potions
{
    class InvincibilityPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Invincibility Potion");
            Tooltip.SetDefault("Grants invincibility");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            //item.buffType = ModContent.BuffType<Buffs.Invincibility>();
            Item.consumable = true;
            Item.rare = ItemRarityID.Green;
            Item.width = dims.Width;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.maxStack = 100;
            Item.useAnimation = 15;
            Item.height = dims.Height;
            Item.buffTime = 600;
            Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().invince = true;
            Item.UseSound = SoundID.Item3;
        }
    }
}
