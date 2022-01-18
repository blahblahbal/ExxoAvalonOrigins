using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Placeable.Light
{
    class JungleTorch : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Torch");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Torch);
            Rectangle dims = item.modItem.GetDims();
            item.createTile = ModContent.TileType<Tiles.Torches>();
            item.width = dims.Width;
            item.height = dims.Height;
            item.placeStyle = 0;
            item.value = Item.sellPrice(0, 0, 2, 0);
            item.notAmmo = true;
            item.flame = true;
            item.rare = ItemRarityID.Orange;
            item.ammo = 8;
            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().torch = 13;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.JungleSpores, 2);
            recipe.AddIngredient(ItemID.BeeWax, 2);
            recipe.SetResult(this, 10);
            recipe.AddRecipe();
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
            if (!item.wet)
            {
                Lighting.AddLight((int)((item.position.X + item.width / 2) / 16f), (int)((item.position.Y + item.height / 2) / 16f), 0.15f, 1.28249991f, 0.52f);
            }
        }

        public override void AutoLightSelect(ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
        {
            dryTorch = true;
        }
    }
}
