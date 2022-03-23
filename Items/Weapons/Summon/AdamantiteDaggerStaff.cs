﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Summon
{
    public class AdamantiteDaggerStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Dagger Staff");
        }

        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            item.summon = true;
            item.damage = 26;
            item.shootSpeed = 14f;
            item.mana = 8;
            item.noMelee = true;
            item.rare = ItemRarityID.LightRed;
            item.width = dims.Width;
            item.useTime = 30;
            item.knockBack = 5.5f;
            item.shoot = ModContent.ProjectileType<Projectiles.Summon.AdamantiteDagger>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.value = Item.sellPrice(0, 3);
            item.useAnimation = 30;
            item.height = dims.Height;
            item.UseSound = SoundID.Item44;
        }
        public override bool CanUseItem(Player player)
        {
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 22);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
