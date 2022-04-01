using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    [AutoloadEquip(EquipType.HandsOn, EquipType.HandsOff)]
    class FrostGauntlet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Gauntlet");
            Tooltip.SetDefault("Melee attacks inflict Frostburn and increases damage and melee speed by 9%\nIncreases knockback and puts a damage-reducing shell around the holder when below 25% life");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.rare = ItemRarityID.Lime;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife <= player.statLifeMax2 * 0.25)
            {
                player.AddBuff(62, 5, true);
            }
            player.frostBurn = true;
            player.kbGlove = true;
            player.meleeSpeed += 0.1f;
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.GetDamage(DamageClass.Ranged) += 0.1f;
            player.frostArmor = true;
        }
    }
}
