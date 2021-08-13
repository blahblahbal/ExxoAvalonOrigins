using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items.AdvancedPotions
{
    class AdvAmmoReservationPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Advanced Ammo Reservation Potion");
            Tooltip.SetDefault("Gives 30% chance to not consume ammo");
        }

        public override void SetDefaults()
        {
            Rectangle dims = item.modItem.GetDims();
            item.width = dims.Width;
            item.height = dims.Height;
            item.buffType = ModContent.BuffType<Buffs.AdvancedBuffs.AdvAmmoReservation>();
            item.UseSound = SoundID.Item3;
            item.consumable = true;
            item.rare = ItemRarityID.Lime;
            item.useTime = 15;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.maxStack = 100;
            item.value = Item.sellPrice(0, 0, 4, 0);
            item.useAnimation = 15;
            
            item.buffTime = 50400;
        }
    }
}