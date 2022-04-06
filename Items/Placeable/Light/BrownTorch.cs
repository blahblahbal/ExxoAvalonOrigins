using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light;

class BrownTorch : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Brown Torch");
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.Torch);
        Rectangle dims = this.GetDims();
        Item.createTile = ModContent.TileType<Tiles.Torches>();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.placeStyle = 5;
        Item.value = Item.sellPrice(0, 0, 0, 15);
        Item.notAmmo = true;
        Item.flame = true;
        Item.ammo = 8;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 18;
    }
    public override void AddRecipes()
    {
        CreateRecipe(3).AddIngredient(ItemID.Torch, 3).AddIngredient(ModContent.ItemType<Material.Zircon>()).Register();
    }
    public override void HoldItem(Player player)
    {
        if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0)
        {
            Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, DustID.WhiteTorch);
        }
        Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
        Lighting.AddLight(position, 1.51372552f, 1.16078436f, 0.9254902f);
    }

    public override void PostUpdate()
    {
        if (!Item.wet)
        {
            Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 1.51372552f, 1.16078436f, 0.9254902f);
        }
    }

    public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
    {
        dryTorch = true;
    }
}