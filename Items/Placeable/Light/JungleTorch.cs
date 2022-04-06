using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light;

class JungleTorch : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Jungle Torch");
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.Torch);
        Rectangle dims = this.GetDims();
        Item.createTile = ModContent.TileType<Tiles.Torches>();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.placeStyle = 0;
        Item.value = Item.sellPrice(0, 0, 2, 0);
        Item.notAmmo = true;
        Item.flame = true;
        Item.rare = ItemRarityID.Orange;
        Item.ammo = 8;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 13;
    }
    public override void AddRecipes()
    {
        CreateRecipe(10).AddIngredient(ItemID.JungleSpores, 2).AddIngredient(ItemID.BeeWax, 2).Register();
    }
    public override void HoldItem(Player player)
    {
        if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0)
        {
            Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, DustID.GreenTorch);
        }
        Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
        Lighting.AddLight(position, 0.15f, 1.28249991f, 0.52f);
    }

    public override void PostUpdate()
    {
        if (!Item.wet)
        {
            Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 0.15f, 1.28249991f, 0.52f);
        }
    }

    public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
    {
        dryTorch = true;
    }
}