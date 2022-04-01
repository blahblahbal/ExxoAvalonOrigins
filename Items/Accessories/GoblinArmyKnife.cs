using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class GoblinArmyKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Goblin Army Knife");
            Tooltip.SetDefault("Immune time after being damaged increased, provides life/mana regen, +7% dmg and the holder can quintuple jump\nTells time, provides light, shows position, +4 block range, can craft certain items by hand, +2% crit, Shows ores/mobs");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.lifeRegen = 2;
            Item.defense = 4;
            Item.rare = ItemRarityID.LightPurple;
            Item.width = dims.Width;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 15, 0, 0);
            Item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.tileSpeed += 1f;
            player.wallSpeed += 1f;
            Player.tileRangeX += 4;
            Player.tileRangeY += 4;
            player.accWatch = 3;
            player.accCompass = 1;
            player.accDepthMeter = 1;
            Lighting.AddLight((int)player.Center.X / 16, (int)player.Center.Y / 16, 2f, 2f, 2f);
            if (player.Avalon().quintJump)
            {
                player.doubleJumpCloud = player.doubleJumpSandstorm = player.doubleJumpBlizzard = true;
            }
            player.jumpBoost = player.Avalon().magnet = player.Avalon().longInvince2 = player.longInvince = player.detectCreature = player.findTreasure = true;
            player.manaRegenDelayBonus++;
            player.manaRegenBonus += 25;
            player.GetDamage(DamageClass.Melee) += 0.07f;
            player.GetDamage(DamageClass.Ranged) += 0.07f;
            player.GetDamage(DamageClass.Magic) += 0.07f;
            player.GetDamage(DamageClass.Summon) += 0.07f;
            player.GetCritChance(DamageClass.Magic) += 2;
            player.GetCritChance(DamageClass.Melee) += 2;
            player.GetCritChance(DamageClass.Ranged) += 2;
        }
    }
}
