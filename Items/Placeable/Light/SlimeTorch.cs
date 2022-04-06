using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light;

class SlimeTorch : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Slime Torch");
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.Torch);
        Rectangle dims = this.GetDims();
        Item.createTile = ModContent.TileType<Tiles.Torches>();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.placeStyle = 2;
        Item.value = Item.sellPrice(0, 0, 0, 15);
        Item.notAmmo = true;
        Item.flame = true;
        Item.ammo = 8;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 15;
    }
    public override void HoldItem(Player player)
    {
        if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0)
        {
            Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, DustID.BlueTorch);
        }
        Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
        Lighting.AddLight(position, 0.25f, 0.7f, 1f);
    }

    public override void PostUpdate()
    {
        if (!Item.wet)
        {
            Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 0.25f, 0.7f, 1f);
        }
    }

    public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
    {
        dryTorch = true;
    }
}