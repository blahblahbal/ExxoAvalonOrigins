using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

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
        Item.defense = 2;
        Item.rare = ItemRarityID.Cyan;
        Item.width = dims.Width;
        Item.value = Item.sellPrice(0, 10, 0, 0);
        Item.accessory = true;
        Item.height = dims.Height;
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
        player.GetDamage(DamageClass.Melee) += 0.1f;
        player.GetCritChance(DamageClass.Melee) += 2;
        player.GetDamage(DamageClass.Ranged) += 0.1f;
        player.GetCritChance(DamageClass.Ranged) += 2;
        player.GetDamage(DamageClass.Magic) += 0.1f;
        player.GetCritChance(DamageClass.Magic) += 2;
        player.GetDamage(DamageClass.Throwing) += 0.1f;
        player.GetCritChance(DamageClass.Throwing) += 2;
        player.pickSpeed -= 0.15f;
        player.GetDamage(DamageClass.Summon) += 0.1f;
        player.minionKB += 0.5f;
    }
}