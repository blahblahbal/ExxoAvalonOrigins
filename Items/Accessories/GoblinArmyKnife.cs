using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories;

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

    public override void AddRecipes()
    {
        CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<GoblinToolbelt>())
            .AddIngredient(ItemID.JellyfishNecklace)
            .AddIngredient(ItemID.DestroyerEmblem)
            .AddIngredient(ItemID.CrossNecklace)
            .AddIngredient(ItemID.BundleofBalloons)
            .AddIngredient(ItemID.TreasureMagnet)
            .AddIngredient(ItemID.SpelunkerPotion, 5)
            .AddIngredient(ItemID.HunterPotion, 5)
            .AddTile(TileID.TinkerersWorkbench);
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
            player.hasJumpOption_Cloud = player.hasJumpOption_Sandstorm = player.hasJumpOption_Blizzard = player.hasJumpOption_Fart = true;
        }
        player.jumpBoost = player.treasureMagnet = player.Avalon().longInvince2 = player.longInvince = player.detectCreature = player.findTreasure = true;
        player.manaRegenDelayBonus++;
        player.manaRegenBonus += 25;
        player.GetDamage(DamageClass.Generic) += 0.07f;
        player.GetCritChance(DamageClass.Generic) += 2;
    }
}
