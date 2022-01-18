using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;

namespace ExxoAvalonOrigins.Hooks
{
    public class LargeGem
    {
        public static void ILDrawPlayer(ILContext il)
        {
            var c = new ILCursor(il);

            // Move il cursor into positon
            if (!c.TryGotoNext(i => i.MatchLdfld<Player>(nameof(Player.ownedLargeGems))))
                return;
            if (!c.TryGotoNext(i => i.MatchLdcI4(0)))
                return;

            // Automatically shift cursor after each emit
            c.MoveAfterLabels();

            // Make game skip original drawing of gems
            c.Emit(OpCodes.Pop);
            c.Emit(OpCodes.Ldc_I4_0);
        }
    }
}
