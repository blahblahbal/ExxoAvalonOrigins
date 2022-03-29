using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
{
    class ThornHeartAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorned Heart Amulet");
            Tooltip.SetDefault("Damage increases as your health drops");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.accessory = true;
            item.value = Item.sellPrice(0, 2);
            item.height = dims.Height;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.Chain);
            r.AddIngredient(ItemID.LifeCrystal);
            r.AddIngredient(ItemID.Stinger, 6);
            r.AddIngredient(ItemID.SoulofNight, 8);
            r.AddTile(TileID.TinkerersWorkbench);
            r.SetResult(this);
            r.AddRecipe();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            float dmg = (2 * (float)Math.Floor((player.statLifeMax2 - (double)player.statLife) / player.statLifeMax2 * 10)) / 50;
            if (dmg < 0) dmg = 0;
            //Main.NewText(player.statLifeMax2);
            player.allDamage += dmg;
        }
    }
}
