using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Consumables;

class SunCharm : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sun Charm");
        Tooltip.SetDefault("Summons a Solar Eclipse");
    }

    public override void SetDefaults()
    {
        Rectangle dims = this.GetDims();
        Item.consumable = true;
        Item.rare = ItemRarityID.Yellow;
        Item.width = dims.Width;
        Item.useTime = 40;
        Item.shoot = ModContent.ProjectileType<Projectiles.SunCharm>();
        Item.useStyle = ItemUseStyleID.Swing;
        Item.maxStack = 999;
        Item.useAnimation = 40;
        Item.height = dims.Height;
    }

    public override bool CanUseItem(Player player)
    {
        if (!Main.dayTime) return false;
        return true;
    }
}