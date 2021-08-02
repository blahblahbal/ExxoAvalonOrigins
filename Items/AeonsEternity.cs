using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace ExxoAvalonOrigins.Items
{
	class AeonsEternity : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Aeon's Eternity");
		}
		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/AeonsEternity");
			item.damage = 36;
			item.scale = 1.1f;
			item.melee = true;
			item.autoReuse = true;
			item.useTurn = true;
			item.rare = 5;
			item.width = dims.Width;
			item.height = dims.Height;
			item.useTime = 30;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5f;
			item.shoot = ModContent.ProjectileType<Projectiles.AeonBeam2>();
			item.shootSpeed = 9f;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(0, 1, 0, 0);
		}

        //public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        //{
        //    bool hasDebuff = false;
        //    for (int i = 0; i < target.buffType.Length; i++)
        //    {
        //        if (Main.debuff[target.buffType[i]])
        //        {
        //            hasDebuff = true;
        //            break;
        //        }
        //    }
        //    if (hasDebuff) damage *= 2;
        //}
    }
}