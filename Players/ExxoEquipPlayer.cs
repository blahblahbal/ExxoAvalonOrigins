using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExxoAvalonOrigins.Prefixes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace ExxoAvalonOrigins.Players;
partial class ExxoModPlayer
{
    public override void UpdateEquips()
    {
        if (tomeItem.stack > 0)
        {
            Player.VanillaUpdateEquip(tomeItem);
        }
    }
    public override void PostUpdateEquips()
    {
        for (int i = 0; i < 3; i++)
        {
            ArmorPrefix prefix;
            if ((prefix = PrefixLoader.GetPrefix(Player.armor[i].prefix) as ArmorPrefix) != null)
            {
                //int kb = prefix.PreUpdateEquip(player);
                prefix.UpdateEquip(Player);
            }
        }
        //player.statMana = statManaMax3;
        //statManaMax2 = player.statManaMax2;
        if (meleeStealth && armorStealth)
        {
            if (Player.itemAnimation > 0)
            {
                Player.stealthTimer = 5;
            }
            if (Player.velocity.X > -0.1 && Player.velocity.X < 0.1 && Player.velocity.Y > -0.1 && Player.velocity.Y < 0.1)
            {
                if (Player.stealthTimer == 0)
                {
                    Player.stealth -= 0.015f;
                    if (Player.stealth < 0.0)
                    {
                        Player.stealth = 0f;
                    }
                }
            }
            else
            {
                float num23 = Math.Abs(Player.velocity.X) + Math.Abs(Player.velocity.Y);
                Player.stealth += num23 * 0.0075f;
                if (Player.stealth > 1f)
                {
                    Player.stealth = 1f;
                }
            }
            Player.GetDamage(DamageClass.Melee) += (1f - Player.stealth) * 0.4f;
            Player.GetCritChance(DamageClass.Melee) += (int)((1f - Player.stealth) * 8f);
            Player.GetDamage(DamageClass.Ranged) += (1f - Player.stealth) * 0.6f;
            Player.GetCritChance(DamageClass.Ranged) += (int)((1f - Player.stealth) * 10f);
            Player.aggro -= (int)((1f - Player.stealth) * 750f);
            if (Player.stealthTimer > 0)
            {
                Player.stealthTimer--;
            }
        }
        else if (armorStealth)
        {
            if (Player.itemAnimation > 0)
            {
                Player.stealthTimer = 5;
            }
            if (Player.velocity.X > -0.1 && Player.velocity.X < 0.1 && Player.velocity.Y > -0.1 && Player.velocity.Y < 0.1)
            {
                if (Player.stealthTimer == 0)
                {
                    Player.stealth -= 0.015f;
                    if (Player.stealth < 0.0)
                    {
                        Player.stealth = 0f;
                    }
                }
            }
            else
            {
                float num24 = Math.Abs(Player.velocity.X) + Math.Abs(Player.velocity.Y);
                Player.stealth += num24 * 0.0075f;
                if (Player.stealth > 1f)
                {
                    Player.stealth = 1f;
                }
            }
            Player.GetDamage(DamageClass.Ranged) += (1f - Player.stealth) * 0.6f;
            Player.GetCritChance(DamageClass.Ranged) += (int)((1f - Player.stealth) * 10f);
            Player.aggro -= (int)((1f - Player.stealth) * 750f);
            if (Player.stealthTimer > 0)
            {
                Player.stealthTimer--;
            }
        }
        else if (meleeStealth)
        {
            if (Player.itemAnimation > 0)
            {
                Player.stealthTimer = 5;
            }
            if (Player.velocity.X > -0.1 && Player.velocity.X < 0.1 && Player.velocity.Y > -0.1 && Player.velocity.Y < 0.1)
            {
                if (Player.stealthTimer == 0)
                {
                    Player.stealth -= 0.015f;
                    if (Player.stealth < 0.0)
                    {
                        Player.stealth = 0f;
                    }
                }
            }
            else
            {
                float num25 = Math.Abs(Player.velocity.X) + Math.Abs(Player.velocity.Y);
                Player.stealth += num25 * 0.0075f;
                if (Player.stealth > 1f)
                {
                    Player.stealth = 1f;
                }
            }
            Player.GetDamage(DamageClass.Melee) += (1f - Player.stealth) * 0.4f;
            Player.GetCritChance(DamageClass.Melee) += (int)((1f - Player.stealth) * 8f);
            Player.aggro -= (int)((1f - Player.stealth) * 750f);
            if (Player.stealthTimer > 0)
            {
                Player.stealthTimer--;
            }
        }
        else
        {
            Player.stealth = 1f;
        }

        if (inertiaBoots || blahWings)
        {
            if (Player.controlUp && Player.controlJump)
            {
                Player.wingsLogic = 0;
                Player.velocity.Y = Player.velocity.Y - 0.7f * Player.gravDir;
                if (Player.gravDir == 1f)
                {
                    if (Player.velocity.Y > 0f)
                    {
                        Player.velocity.Y = Player.velocity.Y - 1f;
                    }
                    else if (Player.velocity.Y > -Terraria.Player.jumpSpeed)
                    {
                        Player.velocity.Y = Player.velocity.Y - 0.5f;
                    }
                    if (Player.velocity.Y < -Terraria.Player.jumpSpeed * 3f)
                    {
                        Player.velocity.Y = -Terraria.Player.jumpSpeed * 3f;
                    }
                }
                else
                {
                    if (Player.velocity.Y < 0f)
                    {
                        Player.velocity.Y = Player.velocity.Y + 1f;
                    }
                    else if (Player.velocity.Y < Terraria.Player.jumpSpeed)
                    {
                        Player.velocity.Y = Player.velocity.Y + 0.5f;
                    }
                    if (Player.velocity.Y > Terraria.Player.jumpSpeed * 3f)
                    {
                        Player.velocity.Y = Terraria.Player.jumpSpeed * 3f;
                    }
                }
            }
        }

        #region bubble boost

        if (bubbleBoost && activateBubble && !Player.isOnGround() && !Player.releaseJump && !NPC.AnyNPCs(ModContent.NPCType<NPCs.Bosses.ArmageddonSlime>()))
        {
            #region bubble timer and spawn bubble gores/sound

            bubbleCD++;
            if (bubbleCD == 20)
            {
                for (int i = 0; i < 3; i++)
                {
                    int g1 = Gore.NewGore(Player.Center + new Vector2(Main.rand.Next(-32, 33), Main.rand.Next(-32, 33)), Player.velocity, Mod.Find<ModGore>("Bubble").Type, 1f);
                    SoundEngine.PlaySound(SoundID.Item, (int)Player.position.X, (int)Player.position.Y, SoundLoader.GetSoundSlot(Mod, "Sounds/Item/Bubbles"));
                }
            }
            if (bubbleCD == 30)
            {
                for (int i = 0; i < 2; i++)
                {
                    int g1 = Gore.NewGore(Player.Center + new Vector2(Main.rand.Next(-32, 33), Main.rand.Next(-32, 33)), Player.velocity, Mod.Find<ModGore>("LargeBubble").Type, 1f);
                }
            }
            if (bubbleCD == 40)
            {
                for (int i = 0; i < 4; i++)
                {
                    int g1 = Gore.NewGore(Player.Center + new Vector2(Main.rand.Next(-32, 33), Main.rand.Next(-32, 33)), Player.velocity, Mod.Find<ModGore>("SmallBubble").Type, 1f);
                }
                bubbleCD = 0;
            }

            #endregion bubble timer and spawn bubble gores/sound

            #region down

            if (Player.controlDown && Player.controlJump)
            {
                Player.wingsLogic = 0;
                Player.rocketBoots = 0;
                if (Player.controlLeft)
                {
                    Player.velocity.X = -15f;
                }
                else if (Player.controlRight)
                {
                    Player.velocity.X = 15f;
                }
                else
                {
                    Player.velocity.X = 0f;
                }
                Player.velocity.Y = 15f;
                bubbleBoostActive = true;
            }

            #endregion down

            #region up

            else if (Player.controlUp && Player.controlJump)
            {
                Player.wingsLogic = 0;
                Player.rocketBoots = 0;
                if (Player.controlLeft)
                {
                    Player.velocity.X = -15f;
                }
                else if (Player.controlRight)
                {
                    Player.velocity.X = 15f;
                }
                else
                {
                    Player.velocity.X = 0f;
                }
                Player.velocity.Y = -15f;
                bubbleBoostActive = true;
            }

            #endregion up

            #region left

            else if (Player.controlLeft && Player.controlJump)
            {
                Player.velocity.X = -15f;
                Player.wingsLogic = 0;
                Player.rocketBoots = 0;
                if (Player.gravDir == 1f && Player.velocity.Y > -Player.gravity)
                {
                    Player.velocity.Y = -(Player.gravity + 1E-06f);
                }
                else if (Player.gravDir == -1f && Player.velocity.Y < Player.gravity)
                {
                    Player.velocity.Y = Player.gravity + 1E-06f;
                }
                bubbleBoostActive = true;
            }

            #endregion left

            #region right

            else if (Player.controlRight && Player.controlJump)
            {
                Player.velocity.X = 15f;
                Player.wingsLogic = 0;
                Player.rocketBoots = 0;
                if (Player.gravDir == 1f && Player.velocity.Y > -Player.gravity)
                {
                    Player.velocity.Y = -(Player.gravity + 1E-06f);
                }
                else if (Player.gravDir == -1f && Player.velocity.Y < Player.gravity)
                {
                    Player.velocity.Y = Player.gravity + 1E-06f;
                }
                bubbleBoostActive = true;
            }

            #endregion right

            stayInBounds(Player.position);
        }

        #endregion bubble boost

        if (chaosCharm)
        {
            int modCrit = 2 * (int)Math.Floor((Player.statLifeMax2 - (double)Player.statLife) /
                Player.statLifeMax2 * 10.0);
            Player.AllCrit(modCrit);
        }

        if (defDebuff)
        {
            bool flag = false;
            for (int num22 = 0; num22 < 22; num22++)
            {
                if (Main.debuff[Player.buffType[num22]] && Player.buffType[num22] != BuffID.Horrified &&
                    Player.buffType[num22] != BuffID.PotionSickness && Player.buffType[num22] != BuffID.Merfolk &&
                    Player.buffType[num22] != BuffID.Werewolf && Player.buffType[num22] != BuffID.TheTongue &&
                    Player.buffType[num22] != BuffID.ManaSickness && Player.buffType[num22] != BuffID.Wet &&
                    Player.buffType[num22] != BuffID.Slimed && Player.buffType[num22] != ModContent.BuffType<Buffs.StaminaDrain>())
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                defDebuffBonusDef = 12; // defDebuffBonusDef is here to avoid the def buff sticking around 24/7 because of terraria code jank
            }
            else
            {
                defDebuffBonusDef = 0;
            }
        }
        Player.statDefense += defDebuffBonusDef; // outside of the if statement to remove extra defense

        if (teleportV || tpStam)
        {
            if (tpCD > 300)
            {
                tpCD = 300;
            }
            tpCD++;
        }
        stamFlightRestoreCD++;
        if (stamFlightRestoreCD > 3600)
        {
            stamFlightRestoreCD = 3600;
        }

        if (astralProject)
        {
            if (astralCD > 3600)
            {
                astralCD = 3600;
            }

            astralCD++;
        }

        if (curseOfIcarus)
        {
            Player.wingsLogic = 0;
            if (Player.mount.CanFly() || Player.mount.CanHover()) // Setting player.mount._flyTime does not work for all mounts. Bye-bye mounts!
            {
                Player.mount.Dismount(Player);
            }

            // Alternative code which limits flight time instead of disabling it
            /*
            if (player.wingTime > 30)
                player.wingTime = 30;
            */
        }
    }
}
