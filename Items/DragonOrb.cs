using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;using Terraria.DataStructures;

namespace ExxoAvalonOrigins.Items{	class DragonOrb : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Dragon Orb");            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 8));
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/DragonOrb");			item.rare = 2;			item.width = dims.Width;			item.value = Item.sellPrice(0, 0, 2, 0);			item.maxStack = 999;			item.height = 26;		}	}}