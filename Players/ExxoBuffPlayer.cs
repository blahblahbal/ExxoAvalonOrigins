using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.Audio;
using ExxoAvalonOrigins.Items.Accessories;
using ExxoAvalonOrigins.Buffs;

namespace ExxoAvalonOrigins.Players;

partial class ExxoModPlayer
{
    private bool daggerBuffLock;
    public float DaggerStaffRotation { get; private set; }

    public void UpdateDaggerStaff()
    {
        if (daggerBuffLock)
        {
            return;
        }

        DaggerStaffRotation = (DaggerStaffRotation % MathHelper.TwoPi) + 0.01f;
        daggerBuffLock = true;
    }

    public override void PreUpdateBuffs()
    {
        daggerBuffLock = false;
        for (int k = 0; k < Player.buffType.Length; k++)
        {
            if (Player.buffType[k] == 37)
            {
                if (Main.wofNPCIndex >= 0 && Main.npc[Main.wofNPCIndex].type == NPCID.WallofFlesh || ExxoAvalonOriginsWorld.wos >= 0 && Main.npc[ExxoAvalonOriginsWorld.wos].type == ModContent.NPCType<NPCs.Bosses.WallofSteel>())
                {
                    Player.gross = true;
                    Player.buffTime[k] = 10;
                }
                else
                {
                    Player.DelBuff(k);
                    k--;
                }
            }
        }
    }
    public override void UpdateBadLifeRegen()
    {
        if (darkInferno)
        {
            if (Player.lifeRegen > 0)
            {
                Player.lifeRegen = 0;
            }
            Player.lifeRegenTime = 0;
            if (duraShield && Main.rand.Next(6) == 0)
            {
                Player.lifeRegen += Player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) ? 6 : 4;
            }
            else
            {
                Player.lifeRegen -= 16;
            }
        }
        if (caesiumPoison)
        {
            if (Player.lifeRegen > 0)
            {
                Player.lifeRegen = 0;
            }
            Player.lifeRegenTime = 0;
            if (duraShield && Main.rand.Next(6) == 0)
            {
                Player.lifeRegen += Player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()) ? 3 : 2;
            }
            else
            {
                Player.lifeRegen -= 20;
            }
        }
        if (melting)
        {
            if (Player.lifeRegen > 0)
            {
                Player.lifeRegen = 0;
            }
            Player.lifeRegenTime = 0;
            Player.lifeRegen -= 32;
        }
        if (malaria)
        {
            if (Player.lifeRegen > 0)
            {
                Player.lifeRegen = 0;
            }
            Player.lifeRegenTime = 0;
            Player.lifeRegen -= 30;
        }
    }
    public override void UpdateLifeRegen()
    {
        if (duraShield && Main.rand.Next(6) == 0)
        {
            if (Player.poisoned)
            {
                int num = 2;
                if (Player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                {
                    num = 4;
                }

                Player.lifeRegen += num + 4;
            }
            else if (Player.venom || Player.frostBurn || Player.onFire2)
            {
                int num2 = 2;
                if (Player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                {
                    num2 = 4;
                }
                Player.lifeRegen += num2 + 12;
            }
            else if (Player.onFire)
            {
                int num3 = 2;
                if (Player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                {
                    num3 = 4;
                }
                Player.lifeRegen += num3 + 8;
            }
            else if (darkInferno)
            {
                int num6 = 4;
                if (Player.HasItemInArmor(ModContent.ItemType<DurataniumOmegaShield>()))
                {
                    num6 = 8;
                }
                Player.lifeRegen += num6 + 16;
            }
        }
        UpdateStaminaRegen();
    }
    public void UpdateStaminaRegen()
    {
        if (stamRegenDelay > 0)
        {
            stamRegenDelay--;
            if ((Player.velocity.X == 0f && Player.velocity.Y == 0f) || Player.grappling[0] >= 0)
            {
                stamRegenDelay--;
            }
        }
        if (stamRegenDelay <= 0)
        {
            stamRegenDelay = 0;
            stamRegen = statStamMax2 / 7 + 1;
            if ((Player.velocity.X == 0f && Player.velocity.Y == 0f) || Player.grappling[0] >= 0)
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

        while (stamRegenCount >= staminaRegen)
        {
            bool flag = false;
            stamRegenCount -= staminaRegen;
            if (statStam < statStamMax2)
            {
                statStam++;
                flag = true;
            }
            if (statStam >= statStamMax2)
            {
                if (Player.whoAmI == Main.myPlayer && flag)
                {
                    SoundEngine.PlaySound(SoundID.MaxMana, -1, -1, 1);
                    for (int i = 0; i < 5; i++)
                    {
                        int num2 = Dust.NewDust(Player.position, Player.width, Player.height, DustID.ManaRegeneration, 0f, 0f, 255, default(Color), Main.rand.Next(20, 26) * 0.1f);
                        Main.dust[num2].noLight = true;
                        Main.dust[num2].noGravity = true;
                        Main.dust[num2].velocity *= 0.5f;
                    }
                }
                statStam = statStamMax2;
            }
        }
    }
    public void QuickStamina(int stamNeeded = 0) // todo: make stamina flower not allow you to consume stam pots that wouldn't allow you to continue using stamina
    {
        if (Player.noItems)
        {
            return;
        }
        if (statStam == statStamMax2)
        {
            return;
        }
        int num = statStamMax2 - statStam;
        Item potionToBeUsed = null;
        int num2 = -statStamMax2;
        for (int i = 0; i < 58; i++)
        {
            Item potionChecked = Player.inventory[i];
            if (potionChecked.stack > 0 && potionChecked.type > 0 && potionChecked.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina > 0)
            {
                int num3 = potionChecked.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina - num;
                if (num2 < 0)
                {
                    if (num3 > num2)
                    {
                        potionToBeUsed = potionChecked;
                        num2 = num3;
                    }
                }
                else if (num3 < num2 && num3 >= 0)
                {
                    potionToBeUsed = potionChecked;
                    num2 = num3;
                }
            }
        }
        if (potionToBeUsed == null)
        {
            return;
        }
        if (potionToBeUsed.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina < stamNeeded && stamNeeded != 0)
        {
            return;
        }
        SoundEngine.PlaySound(SoundID.Item, (int)Player.position.X, (int)Player.position.Y, 3);
        statStam += potionToBeUsed.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina;
        if (statStam > statStamMax2)
        {
            statStam = statStamMax2;
        }
        if (potionToBeUsed.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina > 0 && Main.myPlayer == Player.whoAmI)
        {
            Player.AddBuff(ModContent.BuffType<StaminaDrain>(), 8 * 60);
            StaminaHealEffect(potionToBeUsed.GetGlobalItem<ExxoAvalonOriginsGlobalItemInstance>().healStamina, true);
        }
        potionToBeUsed.stack--;
        if (potionToBeUsed.stack <= 0)
        {
            potionToBeUsed.type = 0;
        }
    }
    public void StaminaHealEffect(int healAmount, bool broadcast = true)
    {
        CombatText.NewText(Player.getRect(), new Color(5, 200, 255, 255), string.Concat(healAmount), false, false);
        if (broadcast && Main.netMode == 1 && Player.whoAmI == Main.myPlayer)
        {
            ModPacket packet = Network.MessageHandler.GetPacket(Network.MessageID.StaminaHeal);
            packet.Write(Player.whoAmI);
            packet.Write(healAmount);
            packet.Send();
        }
    }
    public override void SyncPlayer(int toWho, int fromWho, bool newPlayer)
    {
        if (newPlayer)
        {
            ModPacket packet = Mod.GetPacket();
            packet.Write(DaggerStaffRotation);
            packet.Send(toWho, fromWho);
        }
    }
}
