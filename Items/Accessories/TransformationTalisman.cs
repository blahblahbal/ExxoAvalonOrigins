using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class TransformationTalisman : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bestial Band");
            Tooltip.SetDefault("Turns the holder into merfolk upon entering water and lava\nTurns the holder into a werewolf at night\nMinor increase to all stats");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.defense = 2;
            item.rare = ItemRarityID.Cyan;
            item.width = dims.Width;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.accessory = true;
            item.height = dims.Height;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var flag2 = Collision.LavaCollision(player.position, player.width, player.height);
            if (flag2)
            {
                player.Avalon().mermanLava = true;
                player.merman = true;
                player.accFlipper = true;
                player.lavaImmune = true;
            }
            player.fireWalk = true;
            player.ignoreWater = true;
            player.accMerman = true;
            player.wolfAcc = true;
            player.lavaImmune = true;
            player.waterWalk = true;
            player.lifeRegen += 2;
            player.statDefense += 4;
            player.meleeSpeed += 0.1f;
            player.meleeDamage += 0.1f;
            player.meleeCrit += 2;
            player.rangedDamage += 0.1f;
            player.rangedCrit += 2;
            player.magicDamage += 0.1f;
            player.magicCrit += 2;
            player.thrownDamage += 0.1f;
            player.thrownCrit += 2;
            player.pickSpeed -= 0.15f;
            player.minionDamage += 0.1f;
            player.minionKB += 0.5f;
        }
    }
}
