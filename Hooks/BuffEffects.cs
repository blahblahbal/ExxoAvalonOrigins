using System;
using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ExxoAvalonOrigins.Hooks
{
    class BuffEffects
    {
        public string[] buffNames =
        {

        };

        public static void OnPickAmmo(On.Terraria.Player.orig_PickAmmo orig, Player self, Item sItem, ref int shoot, ref float speed, ref bool canShoot, ref int Damage, ref float KnockBack, bool dontConsume)
        {
            float advArcheryBuffMult = 1.3f;

            ExxoAvalonOriginsModPlayer modPlayer = self.Avalon();
            if (sItem.useAmmo == AmmoID.Arrow && modPlayer.advArcheryBuff && speed < 20f)
            {
                speed *= advArcheryBuffMult;
                if (speed > 20f)
                {
                    speed = 20f;
                }
            }
            orig(self, sItem, ref shoot, ref speed, ref canShoot, ref Damage, ref KnockBack, dontConsume);
        }

        public static void OnAddBuff(On.Terraria.Player.orig_AddBuff orig, Player self, int type, int time, bool quiet = true)
        {
            for (int j = 0; j < 22; j++)
            {
                if (self.buffType[j] == type)
                {
                    if (type == ModContent.BuffType<Buffs.StaminaDrain>())
                    {
                        self.buffTime[j] += time;
                        if (self.Avalon().staminaDrainStacks < 5)
                        {
                            self.Avalon().staminaDrainStacks++;
                        }
                        if (self.buffTime[j] > ExxoAvalonOriginsModPlayer.staminaDrainTime)
                        {
                            self.buffTime[j] = ExxoAvalonOriginsModPlayer.staminaDrainTime;
                            return;
                        }
                    }
                    else if (self.buffTime[j] < time)
                    {
                        self.buffTime[j] = time;
                    }
                    return;
                }
            }
            orig(self, type, time, quiet);
        }

        public static void ILCatchFish(ILContext il)
        {
            int advCrateBuffAddChance = 15;

            // Advanced crate buff chance implementation
            var c = new ILCursor(il);

            FieldReference fieldPlayer = null;
            FieldReference fieldOwner = null;

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdfld<Player>("cratePotion")))
                return;
            int num19 = 0;
            if (!c.TryGotoNext(i => i.MatchLdloc(out num19)))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdsfld(out fieldPlayer)))
                return;
            if (!c.TryGotoPrev(i => i.MatchLdfld(out fieldOwner)))
                return;
            if (!c.TryGotoNext(i => i.MatchLdfld<Player>("cratePotion")))
                return;

            c.Emit(OpCodes.Ldloc, num19);
            c.EmitDelegate<Func<Player, int, int>>((player, num) =>
            {
                if (player.Avalon().advCrateBuff)
                {
                    num += advCrateBuffAddChance;
                }
                return num;
            });
            c.Emit(OpCodes.Stloc, num19);

            c.Emit(OpCodes.Ldsfld, fieldPlayer);
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldfld, fieldOwner);
            c.Emit(OpCodes.Ldelem_Ref);
        }
    }
}
