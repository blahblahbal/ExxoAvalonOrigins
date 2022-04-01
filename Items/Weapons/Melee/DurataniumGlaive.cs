﻿using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Weapons.Melee
{
    class DurataniumGlaive : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Duratanium Glaive");
        }
        public override void SetDefaults()
        {
            Rectangle dims = this.GetDims();
            Item.UseSound = SoundID.Item1;
            Item.damage = 31;
            Item.noUseGraphic = true;
            Item.scale = 1.1f;
            Item.shootSpeed = 5f;
            Item.rare = ItemRarityID.LightRed;
            Item.noMelee = true;
            Item.width = dims.Width;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 5.1f;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.DurataniumGlaive>();
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = 50000;
            Item.height = dims.Height;
        }
    }
}
