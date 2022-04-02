using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light;

class PathogenTorch : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Pathogen Torch");
    }

    public override void SetDefaults()
    {
        Item.CloneDefaults(ItemID.Torch);
        Rectangle dims = Item.modItem.GetDims();
        Item.createTile = ModContent.TileType<Tiles.Torches>();
        Item.width = dims.Width;
        Item.height = dims.Height;
        Item.placeStyle = 1;
        Item.value = Item.sellPrice(0, 0, 2, 0);
        Item.notAmmo = true;
        Item.flame = true;
        Item.rare = ItemRarityID.Orange;
        Item.ammo = 8;
        Item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 14;
    }
    public override void AddRecipes()
    {
        CreateRecipe(33).AddIngredient(ItemID.Torch, 33).AddIngredient(ModContent.ItemType<Material.Pathogen>()).Register();
    }
    public override void HoldItem(Player player)
    {
        if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0)
        {
            Dust.NewDust(new Vector2(player.itemLocation.X + 16f * player.direction, player.itemLocation.Y - 14f * player.gravDir), 4, 4, DustID.CursedTorch);
        }
        Vector2 position = player.RotatedRelativePoint(new Vector2(player.itemLocation.X + 12f * player.direction + player.velocity.X, player.itemLocation.Y - 14f + player.velocity.Y), true);
        Lighting.AddLight(position, 0.5882353f, 1f, 0.368627459f);
    }

    public override void PostUpdate()
    {
        if (!Item.wet)
        {
            Lighting.AddLight((int)((Item.position.X + Item.width / 2) / 16f), (int)((Item.position.Y + Item.height / 2) / 16f), 0.5882353f, 1f, 0.368627459f);
        }
    }

    public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
    {
        dryTorch = true;
    }
}