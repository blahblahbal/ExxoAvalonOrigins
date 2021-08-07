using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class ZirconStaff : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Zircon Staff");		}        // TODO CRITCHANCE		public override void SetDefaults()		{			item.CloneDefaults(ItemID.SapphireStaff);
			Item.staff[item.type] = true;
            Rectangle dims = ExxoAvalonOrigins.getDims("Items/ZirconStaff");
            //item.magic = true;
            item.damage = 32;
            item.autoReuse = true;
            item.shootSpeed = 7.75f;
            item.mana = 9;
            item.rare = 2;
            //item.noMelee = true;
            item.width = dims.Width;
            //item.useTime = 23;
            item.knockBack = 4.75f;
            item.shoot = ModContent.ProjectileType<Projectiles.ZirconBolt>();
            //item.useStyle = 5;
            item.value = 36000;
            //item.useAnimation = 23;
            item.height = dims.Height;
            item.UseSound = SoundID.Item43;
        }	}}