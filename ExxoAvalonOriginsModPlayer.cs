using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using ExxoAvalonOrigins.Items;
using ExxoAvalonOrigins.Projectiles;
using ExxoAvalonOrigins.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ExxoAvalonOrigins
{
    public class ExxoAvalonOriginsModPlayer : ModPlayer
    {
        #region fields
        public int statStamMax = 300;
        public int statStamMax2 = 300;
        public int statStam = 100;
        public int statManaMax3 = 1500;
        public int statManaMax2 = 100;
        public int statMana = 100;
        public bool shmAcc = false;
        public bool herb = false;
        public bool teleportVWasTriggered = false;
        public enum ShadowMirrorModes
        {
            Spawn,
            Checkpoints,
            Team
        }

        public bool armorStealth = false;
        public int shadowCheckPointNum = 0;
        public int shadowPlayerNum = 0;
        public bool slimeImmune = false;
        public bool beeRepel = false;
        public bool lucky = false;
        public bool melting = false;
        public bool enemySpawns2 = false;
        public int crimsonCount = 0;
        public bool darkInferno = false;
        public int deliriumCount = 0;
        public bool forceField = true;
        public int fAlevel = 0;
        public int fAlastRecord = 0;
        public bool gastroMinion = false;
        public bool hungryMinion = false;
        public bool iceGolem = false;
        public int infectTimer = 0;
        public int infectDmg = 0;
        public bool weaponMinion = false;
        public bool primeMinion = false;
        public int shadowPotCd = 0;
        public bool shockWave = false;
        public int fallStart_old = 0;
        public bool earthInsig = false;
        public bool vision = false;
        public const int deliriumFreq = 600;
        public int crystalHealth = 0;
        public Item tomeItem = new Item();
        public int pl = -1;
        public bool openLocks;
        public bool chaosCharm;
        public short thunderTimer;
        public bool terraClaws;
        public bool thunderBolt;
        public bool incDef;
        public bool regenStrike;
        public bool frontReflect = false;
        public bool slimeBand;
        public bool defDebuff;
        public bool luckTome;
        public float rot;
        public byte qsMode = 1;
        public byte qsTimer;
        public bool qsDone;
        public bool qsIsNDown;
        public bool trapImmune;
        public bool hyperMelee;
        public bool hyperMagic;
        public bool hyperRanged;
        public int hyperBar;
        public bool auraThorns;
        public bool speed;
        public bool Nd;
        public bool oldNd;
        public bool Fd;
        public bool oldFd;
        public bool Bud;
        public bool oldBud;
        public bool Ld;
        public bool oldLd;
        public bool Gd;
        public bool oldGd;
        public bool Brd;
        public bool oldBrd;
        public bool Kd;
        public bool oldKd;
        public bool activateBubble;
        public bool activateSprint;
        public bool activateSwim;
        public bool activateSlide;
        public bool stamDashKey;
        public bool quintJump;
        public bool shadowRing;
        public static bool SpawnDL = false;
        public bool fleshLaser;
        public int teleportToPlayer = -1;
        public bool dashIntoMob;
        public bool dashTemp;
        public bool bubbleBoost;
        public bool bubbleBoostActive;
        public int teamLen;
        public bool rocketJumpRO = true;
        public bool heartGolem;
        public bool ethHeart;
        public byte staminaCD;
        public byte staminaCD2;
        public byte staminaCD3;
        public bool blahArmor;
        public bool shadowTele;
        public bool teleportV = false;
        public int tpCD;
        public bool oblivionKill = false;
        public bool splitProj;
        public bool minionFreeze;
        public int deliriumDuration = 300;
        public bool mermanLava;
        public int quadroCount;
        public int shadowWP = 0;
        public bool confusionTal;
        public bool shadowRO;
        public bool isNDown;
        public bool magnet;
        public Item tome;
        public bool ghostSilence;
        public bool zoneTime;
        public bool zoneBlight;
        public bool zoneFright;
        public bool zoneMight;
        public bool zoneNight;
        public bool zoneTorture;
        public bool zoneBooger;
        public bool zoneDark;
        public bool zoneComet;
        public bool zoneHellcastle;
        public bool meleeStealth;
        public bool releaseQuickStamina;
        public int stamRegen;
        public int stamRegenCount;
        public int stamRegenDelay;
        public bool ammoCost70;
        public bool liaB;
        public bool longInvince2;
        public float kbIncrease;
        public bool accDivingSuit;
        public bool accDivingPants;
        public bool doubleJump5;
        public bool jumpAgain5;
        public bool dJumpEffect5;
        public bool doubleDamage;

        public int herbX;
        public int herbY;
        public int herbTier;
        public int potionTotal;
        public int herbTotal;
        public int[] herbCounts = new int[10];
        private int gemCount = 0;
        private bool[] ownedLargeGems = new bool[10];
        #endregion

        public override void ResetEffects()
        {
            //Main.NewText("" + trapImmune.ToString());
            //Main.NewText("" + slimeBand.ToString());
            //trapImmune = false;
            bubbleBoost = false;
            darkInferno = false;
            melting = false;
        }

        public override void UpdateBadLifeRegen()
        {
            if (darkInferno)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                if (frontReflect && Main.rand.Next(6) == 0)
                {
                    player.lifeRegen += HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) ? 6 : 4;
                }
                else
                {
                    player.lifeRegen -= 16;
                }
            }
            if (melting)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 32;
            }
        }
        public override void UpdateBiomes()
        {
            zoneHellcastle = false;
            if (ExxoAvalonOriginsWorld.hellcastleTiles >= 400)
            {
                int num = (int)player.position.X / 16;
                int num2 = (int)player.position.Y / 16;
                if (Main.tile[num, num2].wall == ModContent.WallType<Walls.ImperviousBrickWallUnsafe>())
                {
                    zoneHellcastle = true;
                }
            }
            zoneBooger = ExxoAvalonOriginsWorld.ickyTiles > 200;
        }
        public override void SendCustomBiomes(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = zoneHellcastle;
            flags[1] = zoneBooger;
            writer.Write(flags);
        }
        
        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            zoneHellcastle = flags[0];
            zoneBooger = flags[1];
        }
        public bool HasItemInArmor(int type)
        {
            for (var i = 0; i < 20; i++)
            {
                if (type == player.armor[i].type)
                {
                    return true;
                }
            }
            return false;
        }

        public override void OnEnterWorld(Player player)
        {
            if (tomeItem.type <= 0) tomeItem.SetDefaults();
            Main.NewText("You are using Exxo Avalon: Origins " + ExxoAvalonOrigins.version.ToString());
            Main.NewText("Please note that Exxo Avalon: Origins is in Beta; it may have many bugs");
            Main.NewText("Please also note that Exxo Avalon: Origins will interact weirdly with other large mods");
        }

        public override void UpdateEquips(ref bool wallSpeedBuff, ref bool tileSpeedBuff, ref bool tileRangeBuff)
        {
            if (tomeItem.stack > 0)
            {
                player.VanillaUpdateEquip(tomeItem);
                player.VanillaUpdateAccessory(player.whoAmI, tomeItem, true, ref wallSpeedBuff, ref tileSpeedBuff,
                    ref tileRangeBuff);
            }
        }
        public override void PreUpdateBuffs()
        {
            for (int k = 0; k < player.buffType.Length; k++)
            if (player.buffType[k] == 37)
            {
                if (Main.wof >= 0 && Main.npc[Main.wof].type == 113 || ExxoAvalonOriginsWorld.wos >= 0 && Main.npc[ExxoAvalonOriginsWorld.wos].type == ModContent.NPCType<NPCs.WallofSteel>())
                {
                    player.gross = true;
                    player.buffTime[k] = 10;
                }
                else
                {
                    player.DelBuff(k);
                    k--;
                }
            }
        }
        public void WOSTongue()
        {
            if (ExxoAvalonOriginsWorld.wos >= 0 && Main.npc[ExxoAvalonOriginsWorld.wos].active)
            {
                float num = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + 40f;
                if (Main.npc[ExxoAvalonOriginsWorld.wos].direction > 0)
                {
                    num -= 96f;
                }
                if (player.position.X + (float)player.width > num && player.position.X < num + 140f && player.gross)
                {
                    player.noKnockback = false;
                    player.Hurt(PlayerDeathReason.ByNPC(ExxoAvalonOriginsWorld.wos), 50, Main.npc[ExxoAvalonOriginsWorld.wos].direction);
                }
                if (!player.gross && player.position.Y > (float)((Main.maxTilesY - 250) * 16) && player.position.X > num - 1920f && player.position.X < num + 1920f)
                {
                    player.AddBuff(37, 10, true);
                    //Main.PlaySound(4, (int)Main.npc[ExxoAvalonOriginsWorld.wos].position.X, (int)Main.npc[ExxoAvalonOriginsWorld.wos].position.Y, 10);
                }
                if (player.gross)
                {
                    if (player.position.Y < (float)((Main.maxTilesY - 200) * 16))
                    {
                        player.AddBuff(38, 10, true);
                    }
                    if (Main.npc[ExxoAvalonOriginsWorld.wos].direction < 0)
                    {
                        if (player.position.X + (float)(player.width / 2) > Main.npc[ExxoAvalonOriginsWorld.wos].position.X + (float)(Main.npc[ExxoAvalonOriginsWorld.wos].width / 2) + 40f)
                        {
                            player.AddBuff(38, 10, true);
                        }
                    }
                    else if (player.position.X + (float)(player.width / 2) < Main.npc[ExxoAvalonOriginsWorld.wos].position.X + (float)(Main.npc[ExxoAvalonOriginsWorld.wos].width / 2) - 40f)
                    {
                        player.AddBuff(38, 10, true);
                    }
                }
                if (player.tongued)
                {
                    player.controlHook = false;
                    player.controlUseItem = false;
                    for (int i = 0; i < 1000; i++)
                    {
                        if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].aiStyle == 7)
                        {
                            Main.projectile[i].Kill();
                        }
                    }
                    Vector2 vector = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
                    float num2 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + (float)(Main.npc[ExxoAvalonOriginsWorld.wos].width / 2) - vector.X;
                    float num3 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y + (float)(Main.npc[ExxoAvalonOriginsWorld.wos].height / 2) - vector.Y;
                    float num4 = (float)Math.Sqrt((double)(num2 * num2 + num3 * num3));
                    if (num4 > 3000f)
                    {
                        //player.lastPosBeforeDeath = this.position;
                        player.KillMe(PlayerDeathReason.ByNPC(ExxoAvalonOriginsWorld.wos), 1000.0, 0, false);
                        return;
                    }
                    if (Main.npc[ExxoAvalonOriginsWorld.wos].position.X < 608f || Main.npc[ExxoAvalonOriginsWorld.wos].position.X > (float)((Main.maxTilesX - 38) * 16))
                    {
                        //this.lastPosBeforeDeath = this.position;
                        player.KillMe(PlayerDeathReason.ByNPC(ExxoAvalonOriginsWorld.wos), 1000.0, 0, false);
                    }
                }
            }
        }

        public override bool ConsumeAmmo(Item weapon, Item ammo)
        {
            var consume = true;
            if (tomeItem.type == ModContent.ItemType<CreatorsTome>() && Main.rand.Next(4) == 0) consume = false;
            if ((tomeItem.type == ModContent.ItemType<TomeofDistance>() || tomeItem.type == ModContent.ItemType<Dominance>() || tomeItem.type == ModContent.ItemType<LoveUpandDown>())&& Main.rand.Next(5) == 0) consume = false;
            if ((tomeItem.type == ModContent.ItemType<ThePlumHarvest>() || tomeItem.type == ModContent.ItemType<Emperor>()) && Main.rand.Next(10) < 3) consume = false;
            if (!consume)
            {
                return false;
            }
            else
            {
                return base.ConsumeAmmo(weapon, ammo);
            }
        }

        public override void Load(TagCompound tag)
        {
            if (tag.ContainsKey("ExxoAvalonOrigins:TomeSlot"))
            {
                tomeItem = ItemIO.Load(tag.Get<TagCompound>("ExxoAvalonOrigins:TomeSlot"));
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:CrystalHealth"))
            {
                crystalHealth = tag.GetAsInt("ExxoAvalonOrigins:CrystalHealth");
                if (crystalHealth > 4) crystalHealth = 4;
                if (player.statLifeMax == 500)
                {
	                player.statLifeMax += crystalHealth *= 25;
	                player.statLifeMax2 += crystalHealth *= 25;
                }
            }

            if (tag.ContainsKey("ExxoAvalonOrigins:Stamina"))
            {
	            statStamMax = tag.GetAsInt("ExxoAvalonOrigins:Stamina");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:SHMAcc"))
            {
                shmAcc = tag.Get<bool>("ExxoAvalonOrigins:SHMAcc");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:HerbTier"))
            {
                herbTier = tag.GetAsInt("ExxoAvalonOrigins:HerbTier");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:HerbTotal"))
            {
                herbTotal = tag.GetAsInt("ExxoAvalonOrigins:HerbTotal");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:PotionTotal"))
            {
                potionTotal = tag.GetAsInt("ExxoAvalonOrigins:PotionTotal");
            }
            if (tag.ContainsKey("ExxoAvalonOrigins:HerbCounts"))
            {
                herbCounts = tag.Get<int[]>("ExxoAvalonOrigins:HerbCounts");
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (HasItemInArmor(ModContent.ItemType<VampireTeeth>()))
            {
                if (item.melee)
                {
                    if (target.boss) vampireHeal(damage / 2, target.Center);
                    else vampireHeal(damage, target.Center);
                }
            }
        }
        public void vampireHeal(int dmg, Vector2 Position)
        {
            float num = dmg * 0.075f;
            if ((int)num == 0)
            {
                return;
            }
            if (player.lifeSteal <= 0f)
            {
                return;
            }
            player.lifeSteal -= num;
            int num2 = player.whoAmI;
            Projectile.NewProjectile(Position.X, Position.Y, 0f, 0f, 305, 0, 0f, player.whoAmI, (float)num2, num);
        }
        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (auraThorns && !player.immune && !npc.dontTakeDamage)
            {
                int x = (int)player.position.X;
                int y = (int)player.position.Y;
                foreach (NPC N2 in Main.npc)
                {
                    if (N2.position.X >= x - 620 && N2.position.X <= x + 620 && N2.position.Y >= y - 620 && N2.position.Y <= y + 620)
                    {
                        if (!N2.active || N2.dontTakeDamage || N2.townNPC || N2.life < 1 || N2.boss || N2.realLife >= 0 || N2.type == ModContent.NPCType<NPCs.Juggernaut>()) continue;
                        N2.StrikeNPC(damage, 5f, 1);
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(28, -1, -1, NetworkText.FromLiteral(""), N2.whoAmI, (float)damage, 0f, 0f, 0);
                        }
                    }
                }
            }
            if (doubleDamage && !player.immune && !npc.dontTakeDamage)
            {
                npc.StrikeNPC(npc.damage * 2, 2f, 1);
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (hyperMelee)
            {
                hyperBar++;
                if (hyperBar > 15 && hyperBar <= 25)
                {
                    crit = true;
                    if (hyperBar == 25) hyperBar = 0;
                }
            }
            if (confusionTal && Main.rand.Next(100) <= 12)
            {
                target.AddBuff(BuffID.Confused, 540);
            }
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<SwordNet>() || player.inventory[player.selectedItem].type == ModContent.ItemType<ExcaliburNet>() || player.inventory[player.selectedItem].type == ModContent.ItemType<Oblivionet>())
            {
                if (target.catchItem > 0)
                {
                    NPC.CatchNPC(target.whoAmI, player.whoAmI);
                }
            }
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (hyperMelee && proj.melee)
            {
                hyperBar++;
                if (hyperBar > 15 && hyperBar <= 25)
                {
                    crit = true;
                    if (hyperBar == 25) hyperBar = 0;
                }
            }
            if (hyperRanged && proj.ranged)
            {
                hyperBar++;
                if (hyperBar > 15 && hyperBar <= 25)
                {
                    crit = true;
                    if (hyperBar == 25) hyperBar = 0;
                }
            }
            if (hyperMagic && proj.magic)
            {
                hyperBar++;
                if (hyperBar > 15 && hyperBar <= 25)
                {
                    crit = true;
                    if (hyperBar == 25) hyperBar = 0;
                }
            }
        }

        public override void ModifyDrawInfo(ref PlayerDrawInfo drawInfo)
        {
            if (HasItemInArmor(ModContent.ItemType<ShadowRing>())) drawInfo.shadow = 0f;
            if (blahArmor) drawInfo.shadow = 0f;
        }

        public override void UpdateLifeRegen()
        {
	        if (frontReflect && Main.rand.Next(6) == 0)
	        {
		        if (player.poisoned)
		        {
			        int num = 2;
			        if (HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
			        {
				        num = 4;
			        }

			        player.lifeRegen += num + 4;
		        }
		        else if (player.venom || player.frostBurn || player.onFire2)
		        {
			        int num2 = 2;
			        if (HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
			        {
				        num2 = 4;
			        }
			        player.lifeRegen += num2 + 12;
		        }
		        else if (player.onFire)
		        {
			        int num3 = 2;
			        if (HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
			        {
				        num3 = 4;
			        }
			        player.lifeRegen += num3 + 8;
		        }
		        else if (darkInferno)
		        {
			        int num6 = 4;
			        if (HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
			        {
				        num6 = 8;
			        }
			        player.lifeRegen += num6 + 16;
		        }
	        }
	        UpdateStaminaRegen();
        }

        public override TagCompound Save()
        {
            var tag = new TagCompound
            {
                { "ExxoAvalonOrigins:TomeSlot", ItemIO.Save(tomeItem) },
                { "ExxoAvalonOrigins:CrystalHealth", crystalHealth },
                { "ExxoAvalonOrigins:Stamina", statStamMax},
                { "ExxoAvalonOrigins:SHMAcc", shmAcc },
                { "ExxoAvalonOrigins:HerbTier", herbTier },
                { "ExxoAvalonOrigins:HerbTotal", herbTotal },
                { "ExxoAvalonOrigins:PotionTotal", potionTotal },
                { "ExxoAvalonOrigins:HerbCounts", herbCounts }
            };
            return tag;
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (ExxoAvalonOrigins.godMode) return false;
            return true;
        }

        public override void PostUpdate()
        {
            Vector2 pposTile = player.Center / 16;
            for (int xpos = (int)pposTile.X - 4; xpos <= (int)pposTile.X + 4; xpos++)
            {
                for (int ypos = (int)pposTile.Y - 4; ypos <= (int)pposTile.Y + 4; ypos++)
                {
                    if (Main.tile[xpos, ypos].type == (ushort)ModContent.TileType<Tiles.TritanoriumOre>() || Main.tile[xpos, ypos].type == (ushort)ModContent.TileType<Tiles.PyroscoricOre>())
                    {
                        player.AddBuff(ModContent.BuffType<Buffs.Melting>(), 60);
                    }
                }
            }
            if (NPC.AnyNPCs(ModContent.NPCType<NPCs.ArmageddonSlime>()))
            {
                int arma = NPC.FindFirstNPC(ModContent.NPCType<NPCs.ArmageddonSlime>());
                if (arma != -1)
                {
                    Rectangle rectangle = new Rectangle((int)Main.screenPosition.X + (int)player.position.X, (int)Main.screenPosition.Y + (int)player.position.Y, Main.screenWidth, Main.screenHeight);
                    int radius = 5000;
                    Rectangle value = new Rectangle((int)(Main.npc[arma].position.X + (float)(Main.npc[arma].width / 2)) - radius, (int)(Main.npc[arma].position.Y + (float)(Main.npc[arma].height / 2)) - radius, radius * 2, radius * 2);
                    if (rectangle.Intersects(value))
                    {
                        player.wingTime = 0;
                        player.wingsLogic = 0;
                    }
                }
            }
            if (HasItemInArmor(ModContent.ItemType<ShadowRing>())) player.shadow = 0f;
            if (blahArmor) player.shadow = 0f;

            if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb)
            {
                int num9 = (int)((player.position.X + player.width * 0.5) / 16.0);
                int num10 = (int)((player.position.Y + player.height * 0.5) / 16.0);
                if (num9 < herbX - Player.tileRangeX || num9 > herbX + Player.tileRangeX + 1 || num10 < herbY - Player.tileRangeY || num10 > herbY + Player.tileRangeY + 1)
                {
                    Main.PlaySound(11, -1, -1, 1);
                    player.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb = false;
                    player.dropItemCheck();
                }
            }
            if (!Main.playerInventory) player.GetModPlayer<ExxoAvalonOriginsModPlayer>().herb = false;
            if (shmAcc) player.extraAccessorySlots++;
            if (chaosCharm)
            {
                var lvl = 9 - (int)Math.Floor((10.0 * player.statLife) / player.statLifeMax2);
                if (lvl < 0) lvl = 0;
                player.meleeCrit += 2 * lvl;
                player.magicCrit += 2 * lvl;
                player.rangedCrit += 2 * lvl;
                player.thrownCrit += 2 * lvl;
            }
            chaosCharm = false;
            slimeImmune = false;
            if (player.tongued)
            {
                bool flag21 = false;
                if (ExxoAvalonOriginsWorld.wos >= 0)
                {
                    float num159 = Main.npc[ExxoAvalonOriginsWorld.wos].position.X + (float)(Main.npc[ExxoAvalonOriginsWorld.wos].width / 2);
                    num159 += (float)(Main.npc[ExxoAvalonOriginsWorld.wos].direction * 200);
                    float num160 = Main.npc[ExxoAvalonOriginsWorld.wos].position.Y + (float)(Main.npc[ExxoAvalonOriginsWorld.wos].height / 2);
                    Vector2 vector5 = new Vector2(player.position.X + (float)player.width * 0.5f, player.position.Y + (float)player.height * 0.5f);
                    float num161 = num159 - vector5.X;
                    float num162 = num160 - vector5.Y;
                    float num163 = (float)Math.Sqrt((double)(num161 * num161 + num162 * num162));
                    float num164 = 11f;
                    float num165;
                    if (num163 > num164)
                    {
                        num165 = num164 / num163;
                    }
                    else
                    {
                        num165 = 1f;
                        flag21 = true;
                    }
                    num161 *= num165;
                    num162 *= num165;
                    player.velocity.X = num161;
                    player.velocity.Y = num162;
                    player.position += player.velocity;
                }
                if (flag21 && Main.myPlayer == player.whoAmI)
                {
                    for (int num166 = 0; num166 < 22; num166++)
                    {
                        if (player.buffType[num166] == 38)
                        {
                            player.DelBuff(num166);
                        }
                    }
                }
            }

            // Large gem inventory checking
            gemCount++;
            if (gemCount >= 10)
            {
                player.gem = -1;
                ownedLargeGems = new bool[10];
                gemCount = 0;
                for (int num27 = 0; num27 <= 58; num27++)
                {
                    if (player.inventory[num27].type == 0 || player.inventory[num27].stack == 0)
                    {
                        player.inventory[num27].TurnToAir();
                    }
                    // Vanilla gems
                    if (player.inventory[num27].type >= 1522 && player.inventory[num27].type <= 1527)
                    {
                        player.gem = player.inventory[num27].type - 1522;
                        ownedLargeGems[player.gem] = true;
                    }
                    else if (player.inventory[num27].type == ItemID.LargeAmber)
                    {
                        player.gem = 6;
                        ownedLargeGems[player.gem] = true;
                    }
                    // Modded gems
                    else if (player.inventory[num27].type == ModContent.ItemType<LargeZircon>())
                    {
                        player.gem = 7;
                        ownedLargeGems[player.gem] = true;
                    }
                    else if (player.inventory[num27].type == ModContent.ItemType<LargeTourmaline>())
                    {
                        player.gem = 8;
                        ownedLargeGems[player.gem] = true;
                    }
                    else if (player.inventory[num27].type == ModContent.ItemType<LargePeridot>())
                    {
                        player.gem = 9;
                        ownedLargeGems[player.gem] = true;
                    }
                }
            }
        }

        // Large gem player layer logic
        public static readonly PlayerLayer LargeGemLayer = new PlayerLayer(ExxoAvalonOrigins.mod.Name, "LargeGemLayer", PlayerLayer.FrontAcc, delegate (PlayerDrawInfo drawInfo) {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            bool[] ownedLargeGems = drawPlayer.GetModPlayer<ExxoAvalonOriginsModPlayer>().ownedLargeGems;
            if (ownedLargeGems.Length > 0)
            {
                bool flag2 = false;
                DrawData value = default(DrawData);
                float numGems = 0f;
                for (int num23 = 0; num23 < 10; num23++)
                {
                    if (ownedLargeGems[num23])
                    {
                        numGems += 1f;
                    }
                }
                float num25 = 1f - numGems * 0.06f;
                float num26 = (numGems - 1f) * 4f;
                switch ((int)numGems)
                {
                    case 2:
                        num26 += 10f;
                        break;
                    case 3:
                        num26 += 8f;
                        break;
                    case 4:
                        num26 += 6f;
                        break;
                    case 5:
                        num26 += 6f;
                        break;
                    case 6:
                        num26 += 2f;
                        break;
                    case 7:
                        num26 += 0f;
                        break;
                    case 8:
                        num26 += 0f;
                        break;
                    case 9:
                        num26 += 0f;
                        break;
                    case 10:
                        num26 += 0f;
                        break;
                }
                float rotSpeed = (float)drawPlayer.miscCounter / 300f * ((float)Math.PI * 2f);
                if (numGems > 0f)
                {
                    float spacing = (float)Math.PI * 2f / numGems;
                    float num29 = 0f;
                    Vector2 ringSize = new Vector2(1.5f, 0.85f);
                    List<DrawData> list = new List<DrawData>();
                    for (int num30 = 0; num30 < 10; num30++)
                    {
                        if (!ownedLargeGems[num30])
                        {
                            num29 += 1f;
                            continue;
                        }
                        Vector2 value14 = (rotSpeed + spacing * ((float)num30 - num29)).ToRotationVector2();
                        float num31 = num25;
                        if (flag2)
                        {
                            num31 = MathHelper.Lerp(num25 * 0.7f, 1f, value14.Y / 2f + 0.5f);
                        }

                        Texture2D texture2D4 = null;
                        if (num30 < 7)
                        {
                            texture2D4 = Main.gemTexture[num30];
                        }
                        else
                        {
                            switch (num30)
                            {
                                case 7:
                                    texture2D4 = ModContent.GetModItem(ModContent.ItemType<LargeZircon>()).GetTexture();
                                    break;
                                case 8:
                                    texture2D4 = ModContent.GetModItem(ModContent.ItemType<LargeTourmaline>()).GetTexture();
                                    break;
                                case 9:
                                    texture2D4 = ModContent.GetModItem(ModContent.ItemType<LargePeridot>()).GetTexture();
                                    break;
                            }
                        }
                        
                        value = new DrawData(texture2D4, new Vector2((int)(drawInfo.position.X - Main.screenPosition.X + (float)(drawPlayer.width / 2)), (int)(drawInfo.position.Y - Main.screenPosition.Y + (float)drawPlayer.height - 80f)) + value14 * ringSize * num26, null, new Color(250, 250, 250, (int)Main.mouseTextColor / 2), 0f, texture2D4.Size() / 2f, ((float)(int)Main.mouseTextColor / 1000f + 0.8f) * num31, SpriteEffects.None, 0);
                        list.Add(value);
                    }
                    if (flag2)
                    {
                        list.Sort(DelegateMethods.CompareDrawSorterByYScale);
                    }
                    Main.playerDrawData.AddRange(list);
                }
            }
        });

        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            LargeGemLayer.visible = true;
            layers.Add(LargeGemLayer);
        }

        // Large gem drop on death logic
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                player.trashItem.SetDefaults();
                if (player.difficulty == 0)
                {
                    for (int i = 0; i < 59; i++)
                    {
                        if (player.inventory[i].stack > 0 && 
                            (player.inventory[i].type == ModContent.ItemType<LargeZircon>() || 
                            player.inventory[i].type == ModContent.ItemType<LargeTourmaline>() ||
                            player.inventory[i].type == ModContent.ItemType<LargePeridot>()))
                        {
                            int num = Item.NewItem((int)player.position.X, (int)player.position.Y, player.width, player.height, player.inventory[i].type);
                            Main.item[num].netDefaults(player.inventory[i].netID);
                            Main.item[num].Prefix(player.inventory[i].prefix);
                            Main.item[num].stack = player.inventory[i].stack;
                            Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
                            Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
                            Main.item[num].noGrabDelay = 100;
                            Main.item[num].favorited = false;
                            Main.item[num].newAndShiny = false;
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(21, -1, -1, null, num);
                            }
                            player.inventory[i].SetDefaults();
                        }
                    }
                }
            }
        }

        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (player.whoAmI == Main.myPlayer && incDef)
            {
                int time = 300;
                if (HasItemInArmor(ModContent.ItemType<CobaltOmegaShield>()))
                {
                    time = 600;
                }
                player.AddBuff(BuffID.Ironskin, time, true);
            }

            if (player.whoAmI == Main.myPlayer && regenStrike)
            {
                int hpHealed = 5;
                if (HasItemInArmor(ModContent.ItemType<PalladiumOmegaShield>()))
                {
                    hpHealed = 10;
                }

                player.statLife += hpHealed;
                player.HealEffect(hpHealed, true);
            }
        }

        public override void PostUpdateEquips()
        {
            statManaMax2 = player.statManaMax2;
			if (meleeStealth && armorStealth)
			{
				if (player.itemAnimation > 0)
				{
					player.stealthTimer = 5;
				}
				if ((double)player.velocity.X > -0.1 && (double)player.velocity.X < 0.1 && (double)player.velocity.Y > -0.1 && (double)player.velocity.Y < 0.1)
				{
					if (player.stealthTimer == 0)
					{
						player.stealth -= 0.015f;
						if ((double)player.stealth < 0.0)
						{
							player.stealth = 0f;
						}
					}
				}
				else
				{
					float num23 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
					player.stealth += num23 * 0.0075f;
					if (player.stealth > 1f)
					{
						player.stealth = 1f;
					}
				}
				player.meleeDamage += (1f - player.stealth) * 0.4f;
				player.meleeCrit += (int)((1f - player.stealth) * 8f);
				player.rangedDamage += (1f - player.stealth) * 0.6f;
				player.rangedCrit += (int)((1f - player.stealth) * 10f);
				player.aggro -= (int)((1f - player.stealth) * 750f);
				if (player.stealthTimer > 0)
				{
					player.stealthTimer--;
				}
			}
			else if (armorStealth)
			{
				if (player.itemAnimation > 0)
				{
					player.stealthTimer = 5;
				}
				if ((double)player.velocity.X > -0.1 && (double)player.velocity.X < 0.1 && (double)player.velocity.Y > -0.1 && (double)player.velocity.Y < 0.1)
				{
					if (player.stealthTimer == 0)
					{
						player.stealth -= 0.015f;
						if ((double)player.stealth < 0.0)
						{
							player.stealth = 0f;
						}
					}
				}
				else
				{
					float num24 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
					player.stealth += num24 * 0.0075f;
					if (player.stealth > 1f)
					{
						player.stealth = 1f;
					}
				}
				player.rangedDamage += (1f - player.stealth) * 0.6f;
				player.rangedCrit += (int)((1f - player.stealth) * 10f);
				player.aggro -= (int)((1f - player.stealth) * 750f);
				if (player.stealthTimer > 0)
				{
					player.stealthTimer--;
				}
			}
			else if (meleeStealth)
			{
				if (player.itemAnimation > 0)
				{
					player.stealthTimer = 5;
				}
				if ((double)player.velocity.X > -0.1 && (double)player.velocity.X < 0.1 && (double)player.velocity.Y > -0.1 && (double)player.velocity.Y < 0.1)
				{
					if (player.stealthTimer == 0)
					{
						player.stealth -= 0.015f;
						if ((double)player.stealth < 0.0)
						{
							player.stealth = 0f;
						}
					}
				}
				else
				{
					float num25 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
					player.stealth += num25 * 0.0075f;
					if (player.stealth > 1f)
					{
						player.stealth = 1f;
					}
				}
				player.meleeDamage += (1f - player.stealth) * 0.4f;
				player.meleeCrit += (int)((1f - player.stealth) * 8f);
				player.aggro -= (int)((1f - player.stealth) * 750f);
				if (player.stealthTimer > 0)
				{
					player.stealthTimer--;
				}
			}
			else
			{
				player.stealth = 1f;
			}
	        
	        if (bubbleBoost && activateBubble && !isOnGround() && !player.releaseJump)
	        {
		        if (player.controlDown && player.controlJump)
		        {
			        if (player.controlLeft)
			        {
				        player.velocity.X = -10f;
			        }
			        else if (player.controlRight)
			        {
				        player.velocity.X = 10f;
			        }
			        else
			        {
				        player.velocity.X = 0f;
			        }
			        player.velocity.Y = 10f;
			        bubbleBoostActive = true;
		        }
		        else if (player.controlUp && player.controlJump)
		        {
			        if (player.controlLeft)
			        {
				        player.velocity.X = -10f;
			        }
			        else if (player.controlRight)
			        {
				        player.velocity.X = 10f;
			        }
			        else
			        {
				        player.velocity.X = 0f;
			        }
			        player.velocity.Y = -10f;
			        bubbleBoostActive = true;
		        }
		        else if (player.controlLeft && player.controlJump)
		        {
			        player.velocity.X = -10f;
			        player.velocity.Y = -0.42f;
			        bubbleBoostActive = true;
		        }
		        else if (player.controlRight && player.controlJump)
		        {
			        player.velocity.X = 10f;
			        player.velocity.Y = -0.42f;
			        bubbleBoostActive = true;
		        }
		        stayInBounds(player.position);
	        }
	        
	        
	        if (chaosCharm)
	        {
		        int modCrit = 2 * (int)Math.Floor(((double) player.statLifeMax2 - (double) player.statLife) /
		                      (double) player.statLifeMax2 * 10.0);
				player.meleeCrit += modCrit;
				player.magicCrit += modCrit;
				player.rangedCrit += modCrit;
	        }
	        
	        if (defDebuff)
	        {
                bool flag = false;
		        for (int num22 = 0; num22 < 22; num22++)
		        {
			        if (Main.debuff[player.buffType[num22]] && player.buffType[num22] != BuffID.Horrified &&
			            player.buffType[num22] != BuffID.PotionSickness && player.buffType[num22] != BuffID.Merfolk &&
			            player.buffType[num22] != BuffID.Werewolf && player.buffType[num22] != BuffID.TheTongue &&
			            player.buffType[num22] != BuffID.ManaSickness && player.buffType[num22] != BuffID.Wet &&
			            player.buffType[num22] != BuffID.Slimed)
			        {
                        flag = true;
				        break;
			        }
		        }
                if (flag) player.statDefense += 12;
            }

	        if (teleportV)
	        {
		        if (tpCD > 300)
		        {
			        tpCD = 300;
		        }

		        tpCD++;
	        }
        }

		public static void stayInBounds(Vector2 pos)
		{
			if (pos.X > (float)(Main.maxTilesX - 100))
			{
				pos.X = (float)(Main.maxTilesX - 100);
			}
			if (pos.X < 100f)
			{
				pos.X = 100f;
			}
			if (pos.Y > (float)Main.maxTilesY)
			{
				pos.Y = (float)Main.maxTilesY;
			}
			if (pos.Y < 100f)
			{
				pos.Y = 100f;
			}
		}

		public bool isOnGround()
		{
			return (Main.tile[(int)(player.position.X / 16f), (int)(player.position.Y / 16f) + 3].active() && Main.tileSolid[(int)Main.tile[(int)(player.position.X / 16f), (int)(player.position.Y / 16f) + 3].type]) || (Main.tile[(int)(player.position.X / 16f) + 1, (int)(player.position.Y / 16f) + 3].active() && Main.tileSolid[(int)Main.tile[(int)(player.position.X / 16f) + 1, (int)(player.position.Y / 16f) + 3].type] && player.velocity.Y == 0f);
		}

        public override void PostUpdateMiscEffects()
        {
            if (player.HasItem(ModContent.ItemType<SonicScrewdriverMkI>()))
            {
                player.findTreasure = player.detectCreature = true;
            }
            if (player.HasItem(ModContent.ItemType<SonicScrewdriverMkII>()))
            {
                player.findTreasure = player.detectCreature = true;
                player.accWatch = 3;
                player.accDepthMeter = 1;
                player.accCompass = 1;
            }
            if (player.HasItem(ModContent.ItemType<SonicScrewdriverMkII>()))
            {
                player.findTreasure = player.detectCreature = player.dangerSense = openLocks = true;
                player.accWatch = 3;
                player.accDepthMeter = 1;
                player.accCompass = 1;
            }
            if (statManaMax2 > statManaMax3)
            {
                player.statManaMax2 = statManaMax3;
            }
            else
            {
                player.statManaMax2 = statManaMax2;
            }
        }

        public override void PreUpdate()
        {
            WOSTongue();
	        if (teleportV)
	        {
		        teleportV = false;
		        teleportVWasTriggered = true;
	        }

	        player.breathMax = 200;

            // Large gem trashing logic
            if (player.whoAmI == Main.myPlayer)
            {
                if (
                    player.trashItem.type == ModContent.ItemType<LargeZircon>() ||
                    player.trashItem.type == ModContent.ItemType<LargeTourmaline>() ||
                    player.trashItem.type == ModContent.ItemType<LargePeridot>()
                )
                {
                    player.trashItem.SetDefaults();
                }
            }
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ExxoAvalonOrigins.shadowHotkey.JustPressed && (teleportV || teleportVWasTriggered) && tpCD >= 300)
            {
	            teleportVWasTriggered = false;
                tpCD = 0;
                for (var m = 0; m < 70; m++)
                {
                    Dust.NewDust(player.position, player.width, player.height, 15, player.velocity.X * 0.5f, player.velocity.Y * 0.5f, 150, default(Color), 1.1f);
                }
                player.position.X = Main.mouseX + Main.screenPosition.X;
                player.position.Y = Main.mouseY + Main.screenPosition.Y;
                for (var n = 0; n < 70; n++)
                {
                    Dust.NewDust(player.position, player.width, player.height, 15, 0f, 0f, 150, default(Color), 1.1f);
                }
            }

	        if (ExxoAvalonOrigins.sprintHotkey.JustPressed)
	        {
		        activateSprint = !activateSprint;
		        Main.NewText(!activateSprint ? "Sprinting Off" : "Sprinting On");
	        }

	        if (ExxoAvalonOrigins.dashHotkey.JustPressed)
	        {
		        stamDashKey = !stamDashKey;
		        Main.NewText(!stamDashKey ? "Dashing Off" : "Dashing On");
	        }

	        if (ExxoAvalonOrigins.quintupleHotkey.JustPressed)
	        {
		        quintJump = !quintJump;
		        Main.NewText(!quintJump ? "Quintuple Jump Off" : "Quintuple Jump On");
	        }

	        if (ExxoAvalonOrigins.swimHotkey.JustPressed)
	        {
		        activateSwim = !activateSwim;
		        Main.NewText(!activateSwim ? "Swimming Off" : "Swimming On");
	        }

	        if (ExxoAvalonOrigins.wallSlideHotkey.JustPressed)
	        {
		        activateSlide = !activateSlide;
		        Main.NewText(!activateSlide ? "Wall Sliding Off" : "Wall Sliding On");
	        }

	        if (ExxoAvalonOrigins.bubbleBoostHotkey.JustPressed)
	        {
		        activateBubble = !activateBubble;
		        Main.NewText(!activateBubble ? "Bubble Boost Off" : "Bubble Boost On");
	        }

	        if (player.inventory[player.selectedItem].type == ModContent.ItemType <Items.AccelerationDrill>() && ExxoAvalonOrigins.accDrillModeHotkey.JustPressed)
	        {
		        speed = !speed; //TODO: implement speed
		        if (!speed)
		        {
			        Main.NewText("Acceleration Drill Mode: Normal");
		        }
		        else
		        {
			        Main.NewText("Acceleration Drill Mode: Speed");
		        }
	        }

	        if (Main.netMode != 0 && player.inventory[player.selectedItem].type == ModContent.ItemType<EideticMirror>() &&
	            ExxoAvalonOrigins.mirrorModeHotkey.JustPressed)
	        {
		        int newPlayer = teleportToPlayer;
		        int numPlayersCounted = 0;
		        while (true)
		        {
			        newPlayer++;
			        if (newPlayer >= 255)
			        {
				        newPlayer -= 255;
			        }
			        if (Main.player[newPlayer].active && player.whoAmI != newPlayer && !Main.player[newPlayer].dead && Main.player[Main.myPlayer].team > 0 && Main.player[Main.myPlayer].team == Main.player[newPlayer].team)
			        {
				        Main.NewText("Teleporting to " + Main.player[newPlayer].name + " ready.", 250, 250, 0);
				        teleportToPlayer = newPlayer;
				        break;
			        }
			        numPlayersCounted++;
			        if (numPlayersCounted >= 255)
			        {
				        Main.NewText("There are no valid players on your team.", 250, 0, 0);
				        teleportToPlayer = -1;
				        break;
			        }
		        }
	        }

	        if (player.inventory[player.selectedItem].type == ModContent.ItemType<ShadowMirror>())
	        {
		        player.noFallDmg = true; //TODO: Replace with better anti-fall-damage mechanism.
		        if (ExxoAvalonOrigins.mirrorModeHotkey.JustPressed)
		        {
			        shadowWP++;
			        shadowWP %= 7;
			        switch (shadowWP)
			        {
				        case 0:
					        Main.NewText("Mirror Mode: Spawn point");
					        break;
				        case 1:
					        Main.NewText("Mirror Mode: Dungeon");
					        break;
				        case 2:
					        Main.NewText("Mirror Mode: Jungle" + (ExxoAvalonOriginsWorld.jungleLocationKnown ? "" : " (approx. pos)"));
					        break;
				        case 3:
					        Main.NewText("Mirror Mode: Left Ocean");
					        break;
				        case 4:
					        Main.NewText("Mirror Mode: Right Ocean");
					        break;
				        case 5:
					        Main.NewText("Mirror Mode: Underworld");
					        break;
				        case 6:
					        Main.NewText("Mirror Mode: Random");
					        break;
				        default:
					        throw new IndexOutOfRangeException("Not quite sure how you've managed this, but your shadow mirror's teleportation function is just wrong. Please contact the devs of Endo Avalon, and give a full bug report of all the details of the circumstances leading up to this error.");
			        }
		        }
	        }
        }

		public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
		{
			if (liaB)
			{
				Projectile.NewProjectile(player.position.X + 20f, player.position.Y - 60f, 0f, 0f, ModContent.ProjectileType<LightningCloud>(), 45, 4f, player.whoAmI, 0f, 0f);
			}
		}

	    public override void PostUpdateRunSpeeds()
	    {
            //Main.NewText("PostUpdateRunSpeeds " + slimeBand.ToString());
            FloorVisualsAvalon(player.velocity.Y > player.gravity);
		    if (statStam >= 1 && player.wet && player.velocity != Vector2.Zero && !player.accMerman && activateSwim)
		    {
			    bool flag15 = true;
			    staminaCD += 1;
			    stamRegenCount = 0;
			    if (staminaCD >= 6)
			    {
				    statStam--;
				    if (statStam <= 0)
				    {
					    statStam = 0;
					    flag15 = false;
				    }
				    staminaCD = 0;
			    }
			    if (flag15)
			    {
				    player.accFlipper = true;
			    }
		    }
			if (activateSprint)
			{
				if (player.controlLeft && statStam >= 2 && !HasItemInArmor(ModContent.ItemType<InertiaBoots>()) && !HasItemInArmor(ModContent.ItemType<BlahsWings>()) && player.velocity.X != 0f)
				{
					bool flag16 = true;
					staminaCD2 += 1;
					stamRegenCount = 0;
					if (staminaCD2 >= 15)
					{
						statStam -= 2;
						if (statStam <= 0)
						{
							statStam = 0;
							flag16 = false;
						}
						staminaCD2 = 0;
					}
					if (flag16)
					{
						if (!HasItemInArmor(ItemID.HermesBoots) && !HasItemInArmor(ItemID.FlurryBoots) && !HasItemInArmor(ItemID.SpectreBoots) && !HasItemInArmor(ItemID.LightningBoots) && !HasItemInArmor(ItemID.FrostsparkBoots) && !HasItemInArmor(ItemID.SailfishBoots))
						{
							player.accRunSpeed = 6f;
						}
						else if (!HasItemInArmor(ItemID.LightningBoots) && !HasItemInArmor(ItemID.FrostsparkBoots))
						{
							player.accRunSpeed = 6.75f;
						}
						else
						{
							player.accRunSpeed = 10.29f;
							if (player.velocity.X > -4f)
							{
								player.velocity.X = player.velocity.X - 0.31f;
							}
							if (player.velocity.X < -4f && player.velocity.X > -8f)
							{
								player.velocity.X = player.velocity.X - 0.29f;
							}
						}
					}
				}
				if (player.controlRight && statStam >= 2 && !HasItemInArmor(ModContent.ItemType<InertiaBoots>()) && !HasItemInArmor(ModContent.ItemType<BlahsWings>()) && player.velocity.X != 0f)
				{
					bool flag17 = true;
					staminaCD2 += 1;
					stamRegenCount = 0;
					if (staminaCD2 >= 15)
					{
						statStam -= 2;
						if (statStam <= 0)
						{
							statStam = 0;
							flag17 = false;
						}
						staminaCD2 = 0;
					}
					if (flag17)
					{
						if (!HasItemInArmor(ItemID.HermesBoots) && !HasItemInArmor(ItemID.FlurryBoots) && !HasItemInArmor(ItemID.SpectreBoots) && !HasItemInArmor(ItemID.LightningBoots) && !HasItemInArmor(ItemID.FrostsparkBoots) && !HasItemInArmor(ItemID.SailfishBoots))
						{
							player.accRunSpeed = 6f;
						}
						else if (!HasItemInArmor(ItemID.LightningBoots) && !HasItemInArmor(ItemID.FrostsparkBoots))
						{
							player.accRunSpeed = 6.75f;
						}
						else
						{
							player.accRunSpeed = 10.29f;
							if (player.velocity.X < 4f)
							{
								player.velocity.X = player.velocity.X + 0.31f;
							}
							if (player.velocity.X > 4f && player.velocity.X < 8f)
							{
								player.velocity.X = player.velocity.X + 0.29f;
							}
						}
					}
				}
			}
	    }

	    public void UpdateStaminaRegen()
	    {
		    if (stamRegenDelay > 0)
		    {
			    stamRegenDelay--;
			    if ((player.velocity.X == 0f && player.velocity.Y == 0f) || player.grappling[0] >= 0)
			    {
				    stamRegenDelay--;
			    }
		    }
		    if (stamRegenDelay <= 0)
		    {
			    stamRegenDelay = 0;
			    stamRegen = statStamMax2 / 7 + 1;
			    if ((player.velocity.X == 0f && player.velocity.Y == 0f) || player.grappling[0] >= 0)
			    {
				    stamRegen += statStamMax2 / 2;
			    }
			    float num = statStam / (float)statStamMax2 * 0.8f + 0.2f;
			    stamRegen = (int)(stamRegen * num * 1.15);
		    }
		    else
		    {
			    stamRegen = 0;
		    }
		    stamRegenCount += stamRegen;
		    while (stamRegenCount >= 1300)
		    {
			    bool flag = false;
			    stamRegenCount -= 1300;
			    if (statStam < statStamMax2)
			    {
				    statStam++;
				    flag = true;
			    }
			    if (statStam >= statStamMax2)
			    {
				    if (player.whoAmI == Main.myPlayer && flag)
				    {
					    Main.PlaySound(25, -1, -1, 1);
					    for (int i = 0; i < 5; i++)
					    {
						    int num2 = Dust.NewDust(player.position, player.width, player.height, 45, 0f, 0f, 255, default(Color), Main.rand.Next(20, 26) * 0.1f);
						    Main.dust[num2].noLight = true;
						    Main.dust[num2].noGravity = true;
						    Main.dust[num2].velocity *= 0.5f;
					    }
				    }
				    statStam = statStamMax2;
			    }
		    }
	    }

        public void FloorVisualsAvalon(bool falling)
        {
            int num = (int)((player.position.X + (float)(player.width / 2)) / 16f);
            int num2 = (int)((player.position.Y + (float)player.height) / 16f);
            int num3 = -1;
            if (Main.tile[num - 1, num2] == null)
            {
                Main.tile[num - 1, num2] = new Tile();
            }
            if (Main.tile[num + 1, num2] == null)
            {
                Main.tile[num + 1, num2] = new Tile();
            }
            if (Main.tile[num, num2] == null)
            {
                Main.tile[num, num2] = new Tile();
            }
            if (Main.tile[num, num2].nactive() && Main.tileSolid[(int)Main.tile[num, num2].type])
            {
                num3 = (int)Main.tile[num, num2].type;
            }
            else if (Main.tile[num - 1, num2].nactive() && Main.tileSolid[(int)Main.tile[num - 1, num2].type])
            {
                num3 = (int)Main.tile[num - 1, num2].type;
            }
            else if (Main.tile[num + 1, num2].nactive() && Main.tileSolid[(int)Main.tile[num + 1, num2].type])
            {
                num3 = (int)Main.tile[num + 1, num2].type;
            }
            if (num3 > -1)
            {
                if (num3 == 229 && !HasItemInArmor(ModContent.ItemType<InertiaBoots>()) && !HasItemInArmor(ModContent.ItemType<BlahsWings>()))
                {
                    player.sticky = true;
                }
                else
                {
                    player.sticky = false;
                }
                if (HasItemInArmor(ModContent.ItemType<Items.BandofSlime>()))
                {
                    player.slippy = true;
                    player.slippy2 = true;
                }
                else
                {
                    player.slippy = false;
                    player.slippy2 = false;
                }
            }
        }
        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (player.HasBuff(ModContent.BuffType<Buffs.ShadowCurse>()))
            {
                damage *= 2;
            }
        }
        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
            if (player.HasBuff(ModContent.BuffType<Buffs.ShadowCurse>()))
            {
                damage *= 2;
            }
        }
        public void ShadowTP(int mode, int pid)
	    {
            if (player.HasBuff(37))
            {
                player.KillMe(PlayerDeathReason.ByCustomReason(" tried to escape..."), 3000000, 0);
                return;
            }
            switch (mode)
		    {
			    case 0:
                    player.Spawn();
				    break;
			    case 1: // dungeon
				    player.noFallDmg = true;
                    player.immuneTime = 100;
                    ShadowTeleport.Teleport(0);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(13, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
				    break;
			    case 2: // jungle
				    player.noFallDmg = true;
                    player.immuneTime = 100;
                    Vector2 prePos = player.position;
                    Vector2 pos = prePos;
                    ShadowTeleport.Teleport(1);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(13, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
                    break;
			    case 3: // left ocean
				    player.noFallDmg = true;
                    player.immuneTime = 300;
                    ShadowTeleport.Teleport(2);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(13, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
                    break;
			    case 4: // right ocean
                    player.noFallDmg = true;
                    player.immuneTime = 300;
                    ShadowTeleport.Teleport(3);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(13, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
                    break;
			    case 5: // hell
                    player.noFallDmg = true;
                    player.immuneTime = 100;
                    ShadowTeleport.Teleport(4);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendData(13, number: player.whoAmI);
                    }
                    player.noFallDmg = false;
                    break;
			    case 6: // random
			    {
				    if (Main.netMode == 0)
				    {
					    player.TeleportationPotion();
				    }
				    else if (Main.netMode == 1 && player.whoAmI == Main.myPlayer)
				    {
					    NetMessage.SendData(73, -1, -1, NetworkText.Empty, 0, 0f, 0f, 0f, 0);
				    }

				    break;
			    }
		    }
            int d = 15;
            switch (mode)
            {
                case 0:
                    d = DustID.MagicMirror;
                    break;
                case 1:
                    d = ModContent.DustType<Dusts.DungeonTeleportDust>();
                    break;
                case 2:
                    d = ModContent.DustType<Dusts.JungleTeleportDust>();
                    break;
                case 3:
                case 4:
                    d = ModContent.DustType<Dusts.OceanTeleportDust>();
                    break;
                case 5:
                    d = ModContent.DustType<Dusts.DemonConchDust>();
                    break;
                default:
                    d = DustID.MagicMirror;
                    break;
            }

		    for (int i = 0; i < 70; i++)
			{
				Dust.NewDust(player.position, player.width, player.height, d, 0f, 0f, 150, default(Color), 1.5f);
			}
	    }
    }
}