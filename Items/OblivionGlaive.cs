using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class OblivionGlaive : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Oblivion Glaive");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/OblivionGlaive");			item.damage = 120;
			item.UseSound = SoundID.Item1;			item.noUseGraphic = true;			item.scale = 1f;			item.shootSpeed = 5f;			item.rare = ItemRarityID.Cyan;			item.noMelee = true;			item.width = dims.Width;			item.useTime = 14;
			item.useAnimation = 14;			item.knockBack = 4.5f;			item.shoot = ModContent.ProjectileType<Projectiles.OblivionGlaive>();			item.melee = true;
			item.autoReuse = true;			item.useStyle = ItemUseStyleID.HoldingOut;			item.value = Item.sellPrice(0, 20, 0, 0);			item.height = dims.Height;            item.UseSound = SoundID.Item1;
        }
		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[item.shoot] < 1;
		}	}}