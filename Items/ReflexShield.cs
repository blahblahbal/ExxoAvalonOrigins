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
	[AutoloadEquip(EquipType.Shield)]
	class ReflexShield : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Reflex Shield");
			Tooltip.SetDefault("Gives a chance to reflect projectiles and immunity to most debuffs\nGrants immunity to fire blocks and knockback");
		}

		public override void SetDefaults()
		{
			Rectangle dims = ExxoAvalonOrigins.getDims("Items/ReflexShield");
			item.defense = 6;
			item.rare = 9;
			item.width = dims.Width;
			item.accessory = true;
			item.value = Item.sellPrice(0, 17, 45, 0);
			item.height = dims.Height;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.noKnockback = true;
			player.fireWalk = true;
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.BrokenArmor] = true;
			player.buffImmune[BuffID.Bleeding] = true;
			player.buffImmune[BuffID.Poisoned] = true;
			player.buffImmune[BuffID.Slow] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Silenced] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.Suffocation] = true;
			player.buffImmune[BuffID.Ichor] = true;
			player.buffImmune[BuffID.OnFire] = true;
			player.buffImmune[BuffID.Blackout] = true;
			player.buffImmune[BuffID.CursedInferno] = true;
			var playerWS = new Rectangle((int)player.Center.X - 32, (int)player.Center.Y - 32, 64, 64);
            foreach (Projectile Pr in Main.projectile)
            {
                if (!Pr.friendly && !Pr.bobber && Pr.type != ProjectileID.RainCloudMoving && Pr.type != ProjectileID.RainCloudRaining &&
                    Pr.type != ProjectileID.BloodCloudMoving && Pr.type != ProjectileID.BloodCloudRaining &&
                    Pr.type != ProjectileID.FrostHydra && Pr.type != ProjectileID.InfernoFriendlyBolt &&
                    Pr.type != ProjectileID.InfernoFriendlyBlast && Pr.type != ProjectileID.FlyingPiggyBank)
                {
                    Rectangle proj2 = new Rectangle((int)Pr.position.X, (int)Pr.position.Y, Pr.width, Pr.height);
                    bool reflect = false, check = false;
                    int rn = Main.rand.Next(2);
                    if (rn == 0)
                    {
                        if (proj2.Intersects(playerWS) && !reflect) reflect = true;
                    }
                    else check = true;
                    if (reflect && !check)
                    {
                        for (int thingy = 0; thingy < 5; thingy++)
                        {
                            int dust = Dust.NewDust(Pr.position, Pr.width, Pr.height, 15, 0f, 0f, 100, new Color(), 1f);
                            Main.dust[dust].noGravity = true;
                        }
                        Pr.hostile = false;
                        Pr.friendly = true;
                        Pr.velocity.X *= -1f;
                        Pr.velocity.Y *= -1f;
                    }
                }
            }
            foreach (NPC N in Main.npc)
            {
                if (!N.friendly && N.aiStyle == 9)
                {
                    Rectangle npc = new Rectangle((int)N.position.X, (int)N.position.Y, N.width, N.height);
                    bool reflect = false, check = false;
                    int rn = Main.rand.Next(2);
                    if (rn == 0)
                    {
                        if (npc.Intersects(playerWS) && !reflect) reflect = true;
                    }
                    else check = true;
                    if (reflect && !check)
                    {
                        for (int varlex = 0; varlex < 5; varlex++)
                        {
                            int dust = Dust.NewDust(N.position, N.width, N.height, 15, 0f, 0f, 100, new Color(), 1f);
                            Main.dust[dust].noGravity = true;
                        }
                        N.friendly = true;
                        N.velocity.X *= -1f;
                        N.velocity.Y *= -1f;
                    }
                }
            }
        }
	}
}