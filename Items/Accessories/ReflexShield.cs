using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Items.Accessories
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
            Rectangle dims = this.GetDims();
            item.defense = 6;
            item.rare = ItemRarityID.Cyan;
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
                    Pr.type != ProjectileID.BloodCloudMoving && Pr.type != ProjectileID.BloodCloudRaining && Pr.type != 50 && Pr.type != ProjectileID.Stinger && Pr.type != 53 && Pr.type != 358 &&
                    Pr.type != ProjectileID.FrostHydra && Pr.type != ProjectileID.InfernoFriendlyBolt &&
                    Pr.type != ProjectileID.InfernoFriendlyBlast && Pr.type != ProjectileID.FlyingPiggyBank &&
                    Pr.type != ProjectileID.PhantasmalDeathray && Pr.type != ModContent.ProjectileType<Projectiles.Ghostflame>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.WallofSteelLaser>() && Pr.type != ModContent.ProjectileType<Projectiles.PhantasmLaser>() && Pr.type != ModContent.ProjectileType<Projectiles.PhantasmLaser>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.ElectricBolt>() && Pr.type != ModContent.ProjectileType<Projectiles.HomingRocket>() && Pr.type != ModContent.ProjectileType<Projectiles.StingerLaser>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.CaesiumFireball>() && Pr.type != ModContent.ProjectileType<Projectiles.CaesiumCrystal>() && Pr.type != ModContent.ProjectileType<Projectiles.CaesiumGas>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.SpikyBall>() && Pr.type != ModContent.ProjectileType<Projectiles.Spike>() && Pr.type != ModContent.ProjectileType<Projectiles.CrystalShard>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.WallofSteelLaserEnd>() && Pr.type != ModContent.ProjectileType<Projectiles.WallofSteelLaserStart>() &&
                    Pr.type != ModContent.ProjectileType<Projectiles.CrystalBit>() && Pr.type != ModContent.ProjectileType<Projectiles.CrystalBeam>())
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
                            int dust = Dust.NewDust(Pr.position, Pr.width, Pr.height, DustID.MagicMirror, 0f, 0f, 100, new Color(), 1f);
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
                            int dust = Dust.NewDust(N.position, N.width, N.height, DustID.MagicMirror, 0f, 0f, 100, new Color(), 1f);
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
