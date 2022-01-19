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
            item.lifeRegen = 2;
            item.defense = 4;
            item.rare = ItemRarityID.LightPurple;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 15, 0, 0);
            item.height = dims.Height;
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
            player.meleeDamage += 0.07f;
            player.rangedDamage += 0.07f;
            player.magicDamage += 0.07f;
            player.minionDamage += 0.07f;
            player.magicCrit += 2;
            player.meleeCrit += 2;
            player.rangedCrit += 2;
        }
    }
}
