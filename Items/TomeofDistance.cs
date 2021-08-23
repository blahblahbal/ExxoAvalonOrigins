using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	class TomeofDistance : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Tome of Distance");			Tooltip.SetDefault("Tome\n+15% ranged damage, +40 HP, +20 mana\n20% chance to not consume ammo");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/TomeofDistance");			item.rare = ItemRarityID.LightRed;			item.width = dims.Width;			item.value = 15000;			item.height = dims.Height;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().tome = true;        }        public override void UpdateAccessory(Player player, bool hideVisual)        {            player.rangedDamage += 0.15f;            player.statLifeMax2 += 40;            player.statManaMax2 += 20;        }    }}