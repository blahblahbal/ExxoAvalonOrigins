using Mono.Cecil;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ID;

namespace ExxoAvalonOrigins.Hooks
{
    class BuffEffects
    {
        public static void OnPickAmmo(On.Terraria.Player.orig_PickAmmo orig, Player self, Item sItem, ref int shoot, ref float speed, ref bool canShoot, ref int Damage, ref float KnockBack, bool dontConsume)
        {
            float advArcheryBuffMult = 1.3f;

            ExxoAvalonOriginsModPlayer modPlayer = self.GetModPlayer<ExxoAvalonOriginsModPlayer>();
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
            c.EmitDelegate<Func<Player, int, int>>((player, num) => {
                if (player.GetModPlayer<ExxoAvalonOriginsModPlayer>().advCrateBuff)
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
