using Microsoft.Xna.Framework;using System;using System.Collections.Generic;using System.Linq;using System.Text;using System.Threading.Tasks;using Terraria;using Terraria.ModLoader;using Terraria.ID;namespace ExxoAvalonOrigins.Items{	[AutoloadEquip(EquipType.Wings)]	class BlahsWings : ModItem	{		public override void SetStaticDefaults()		{			DisplayName.SetDefault("Blah's Wings");			Tooltip.SetDefault("Allows flight and slow fall and the wearer can run incredibly fast\nThe wearer has a chance to dodge attacks and negates fall damage");		}		public override void SetDefaults()		{			Rectangle dims = ExxoAvalonOrigins.getDims("Items/BlahsWings");			item.defense = 4;			item.rare = 12;            item.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().avalonRarity = AvalonRarity.Rainbow;
            item.width = dims.Width;			item.value = Item.sellPrice(2, 0, 0, 0);			item.accessory = true;			item.height = dims.Height;		}		public override void UpdateAccessory(Player player, bool hideVisual)		{			player.pStone = true;			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().bubbleBoost = true;			player.GetModPlayer<ExxoAvalonOriginsModPlayer>().trapImmune = player.GetModPlayer<ExxoAvalonOriginsModPlayer>().heartGolem = player.GetModPlayer<ExxoAvalonOriginsModPlayer>().ethHeart = player.GetModPlayer<ExxoAvalonOriginsModPlayer>().longInvince2 = true;            player.wingTime = 1000;            if (player.immune)			{				player.magicCrit += 7;				player.meleeCrit += 7;				player.rangedCrit += 7;				player.magicDamage += 0.07f;				player.meleeDamage += 0.07f;				player.rangedDamage += 0.07f;				player.minionDamage += 0.07f;			}			player.accRunSpeed = 10.29f;			player.rocketBoots = 2;			player.meleeSpeed += 0.15f;			player.noFallDmg = true;			player.blackBelt = true;			player.iceSkate = true;            if (player.controlUp && player.controlJump)
            {
                player.velocity.Y = player.velocity.Y - 0.3f * player.gravDir;
                if (player.gravDir == 1f)
                {
                    if (player.velocity.Y > 0f)
                    {
                        player.velocity.Y = player.velocity.Y - 1f;
                    }
                    else if (player.velocity.Y > -Player.jumpSpeed)
                    {
                        player.velocity.Y = player.velocity.Y - 0.2f;
                    }
                    if (player.velocity.Y < -Player.jumpSpeed * 3f)
                    {
                        player.velocity.Y = -Player.jumpSpeed * 3f;
                    }
                }
                else
                {
                    if (player.velocity.Y < 0f)
                    {
                        player.velocity.Y = player.velocity.Y + 1f;
                    }
                    else if (player.velocity.Y < Player.jumpSpeed)
                    {
                        player.velocity.Y = player.velocity.Y + 0.2f;
                    }
                    if (player.velocity.Y > Player.jumpSpeed * 3f)
                    {
                        player.velocity.Y = Player.jumpSpeed * 3f;
                    }
                }
            }

            if (player.controlLeft)			{				if (player.velocity.X > -5f)				{					player.velocity.X = player.velocity.X - 0.31f;				}				if (player.velocity.X < -5f && player.velocity.X > -10f)				{					player.velocity.X = player.velocity.X - 0.29f;				}			}			if (player.controlRight)			{				if (player.velocity.X < 5f)				{					player.velocity.X = player.velocity.X + 0.31f;				}				if (player.velocity.X > 5f && player.velocity.X < 10f)				{					player.velocity.X = player.velocity.X + 0.29f;				}			}			if (player.velocity.X > 6f || player.velocity.X < -6f)			{				var newColor2 = default(Color);				var num2 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 6, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 100, newColor2, 2f);				Main.dust[num2].noGravity = true;			}			player.wallSpeed += 4.5f;			player.tileSpeed += 4.5f;		}	}}